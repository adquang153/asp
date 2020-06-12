using LiteCommerce.BusinessLayers;
using LiteCommerce.DataLayers.SQLServer;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LiteCommerce.Admin.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class AcountController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult Signout()
        {
            Session.Abandon();
            Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Signin");
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Signin()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Dashboard");
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signin(string email="", string password="")
        {
            password = ToMD5.GetMD5(password);
            //int rowCount = 1;
            //List<Employee> listOfEmployee = CatalogBLL.ListOfEmployees(1, -1, "", out rowCount);
            //foreach(Employee item in listOfEmployee)
            //{
            //    if (item.Email.Equals(email.Trim()) && item.Password.Equals(password))
            //    {
            //        autho = true;
            //    }
            //}
            //Kiểm tra thông tin tài khoản
            UserAccount user = UserACcountBLL.Authorize(email, password, UserAccountTypes.Employee);
            if (user != null)
            {
                //Lưu phiên đăng nhập của user
                WebUserData userData = new WebUserData()
                {
                    UserID = user.UserID,
                    FullName = user.FullName,
                    GroupName = user.GroupName,
                    SessionID = Session.SessionID,
                    ClientIP = Request.UserHostAddress,
                    Photo = user.Photo,
                    LoginTime = DateTime.Now,
                    Title = user.Title,
                };
                FormsAuthentication.SetAuthCookie(userData.ToCookieString(), false);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ModelState.AddModelError("LoginError", "Login Fail!");
                ViewBag.Email = email;
                return View();
            }
            //TODO: Kiểm tra tài khoản thông qua cơ sỏ dữ liệu(database)
            //if(email == "super@gmail.com" && password == "123")
            //{
            //    //Ghi nhận phiên đăng nhập của tài khoản
            //    System.Web.Security.FormsAuthentication.SetAuthCookie(email, false);
            //    //Chuyển trang về Dashboard
            //    return RedirectToAction("Index", "Dashboard");
            //}
            //else
            //{
            //    ModelState.AddModelError("LoginError", "Login Fail!");
            //    ViewBag.Email = email;
            //    return View();
            //}
        }
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}