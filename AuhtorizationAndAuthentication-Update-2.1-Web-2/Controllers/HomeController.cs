using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuthorizationAndAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using AuthorizationAndAuthentication.Enums;

namespace AuthorizationAndAuthentication.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            //Convert.ToInt32("a");
            return View();
        }
        public IActionResult teststatic()
        {
            var a = User.Identity.Name.ToString();

            return Content(a);
        }

        [Authorize(Roles = roleCons.admin)]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [Authorize(Roles = "admin2")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Contacts()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        
        public IActionResult AnauthorizePage() => View();
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize(Policy = "product-view")]
        public IActionResult ProductView()
        {
            return Content("ini halaman view product");
        }
        [Authorize(Policy = "product-save")]
        public IActionResult ProductAdd()
        {
            return Content("ini halaman Add product");
        }
        [Authorize(Policy = "product-edit")]
        public IActionResult ProductEdit()
        {
            return Content("ini halaman Edit product");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                
             return RedirectToAction(nameof(LoginController.Index));
        }      
        
    }
}
