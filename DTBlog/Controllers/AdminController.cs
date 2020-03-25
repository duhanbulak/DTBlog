using DTBlog.Helper;
using Microsoft.AspNetCore.Mvc;

namespace DTBlog.Controllers
{
    [IdentityAuthorization]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}