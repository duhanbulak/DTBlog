using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DTBlog.Helper
{
    public class IdentityAuthorizationAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        //public bool SuperAdminRequired { get; set; } = false;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userInfo = context.HttpContext.Session.GetString("USER_INFO");

            if (string.IsNullOrEmpty(userInfo))
            {
                context.Result = new RedirectToActionResult("Index", "Login", new { });
                return;
            }

            //UserModel user = JsonConvert.DeserializeObject<UserModel>(userInfo);
            //if (SuperAdminRequired && !user.IsSuperAdmin)
            //{
            //    context.Result = new RedirectToActionResult("Index", "SuitHome", new { });
            //    return;
            //}
        }
    }
}
