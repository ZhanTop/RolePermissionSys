using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My.RolePermission.Common;
namespace My.RolePermission.WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        
        //获取验证码
        public ActionResult ShowValideCode()
        {
            ValidateCode vc = new ValidateCode();
            string code= vc.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            Byte[] buffer= vc.CreateValidateGraphic(code);
            return File(buffer, "image/jpeg");
        }
    }
}