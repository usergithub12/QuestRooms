using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using QuestRooms.DAL.Entities;
using QuestRooms.UI.App_Start;
using QuestRooms.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace QuestRooms.UI.Controllers
{
    public class AccountController : Controller
    {
        private AppUserManager _userManager;

        public AppUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        // GET: Account
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Register(UserRegisterVM model)
        {
            var user = new AppUser
            {
                Email = model.Login,
                UserName = model.Login
            };

            var res = UserManager.Create(user, model.Password);

            if (res.Succeeded)
            {
                // AuthenticationManager.SignIn(DefaultAuthenticationTypes.ApplicationCookie);
                return RedirectToAction("Index", "Rooms");
            }
            else
            {
                ViewBag.Errors = res.Errors;
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {

            var user = new AppUser
            {
                Email = model.Login,
                UserName = model.Login
            };
            //////LOGIN
            ClaimsIdentity claim = UserManager.CreateIdentity(user,

DefaultAuthenticationTypes.ApplicationCookie);

            AuthenticationManager.SignOut();

            AuthenticationManager.SignIn(new AuthenticationProperties

            {

                IsPersistent = true

            }, claim);






         ////   var res = AuthenticationManager.SignIn(user, model.Password);
         //               if (res.Succeeded)
         //   {
         //       // AuthenticationManager.SignIn(DefaultAuthenticationTypes.ApplicationCookie);
         //       return RedirectToAction("Index", "Rooms");
         //   }
         //   else
         //   {
         //       ViewBag.Errors = res.Errors;
         //   }
            return View();
        }

    }
}