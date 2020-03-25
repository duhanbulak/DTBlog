using DTBlog.Data.Model;
using DTBlog.DataAccess.UnitOfWork;
using DTBlog.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace DTBlog.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Parolası olmayan birinin alacağı hata 
        /// </summary>
        /// <returns></returns>
        public IActionResult Forbidden()
        {
            return Content("Forbbiden!");
        }

        /// <summary>
        /// Uygulamaya giriş yapar
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SignIn(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Index", "Login");
            }

            using (UnitOfWork uow = new UnitOfWork())
            {
                UserModel user = uow.GetRepository<UserModel>().Get(x =>
                    x.MailAddress.Equals(email, StringComparison.OrdinalIgnoreCase) && x.Password.Equals(Encryption.Md5Encrypt(password)));

                if (user == null)
                {
                    return RedirectToAction("Index", "Login", new { Success = false });
                }

                HttpContext.Session.SetString("USER_INFO", JsonConvert.SerializeObject(user));

                if (user.IsSuperAdmin == true)
                    HttpContext.Session.SetString("USER_NAME", user.Name);

                return RedirectToAction("Index", "Home", false);
            }
        }

        /// <summary>
        /// uygulamadan çıkış yapar
        /// </summary>
        /// <returns></returns>
        [IdentityAuthorization]
        public async Task<IActionResult> SignOut()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        /// <summary>
        /// yeni kullanıcı ekler
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [IdentityAuthorization]
        public IActionResult AddNewUser(UserModel user)
        {
            //TODO: Kullanıcı ekleme sayfası oluşturulacak

            var userModel = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("USER_INFO"));
            if (userModel.IsSuperAdmin == false)
                return Content("Yetkisiz işlem.");

            using (var uow = new UnitOfWork())
            {
                user.Password = Encryption.Md5Encrypt(user.Password);
                uow.GetRepository<UserModel>().Add(user);
                uow.SaveChanges();
            }
            return RedirectToAction();
        }
    }
}
