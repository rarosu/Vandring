using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vandring.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Vandring.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vandring.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<User> userManager;

        public AuthController()
        {
            userManager = new UserManager<User>(new UserStore<User>(new ModelContexts.ModelContext()));
            userManager.UserValidator = new UserValidator<User>(userManager);
        }

        //public ActionResult Login()
        //{
        //    return RedirectToAction("Index", "Home");
        //}

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Find(model.Username, model.Password);
                if (user != null)
                {
                    SignInUser(user);
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password == model.PasswordRepeat)
                {
                    var user = new User
                    {
                        UserName = model.Username
                    };

                    var result = userManager.Create(user, model.Password);
                    if (result.Succeeded)
                    {
                        SignInUser(user);
                        return RedirectToAction("Index", "Account");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Entered passwords do not match");
                }
            }

            return RedirectToAction("Index", "Register");
        }

        private void SignInUser(User user)
        {
            var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            Request.GetOwinContext().Authentication.SignIn(identity);
        }
    }
}