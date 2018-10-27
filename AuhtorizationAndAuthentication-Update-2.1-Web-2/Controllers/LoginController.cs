using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuthorizationAndAuthentication.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
namespace AuthorizationAndAuthentication.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

         [HttpPost]
         public async Task<IActionResult> Login(string username, string password)
        {
            

            if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var claims = new List<Claim>();
                claims.Add( new Claim(ClaimTypes.Name, username));
                claims.Add(new Claim(ClaimTypes.Role, "admin"));
                
                //claims.Add(new Claim("product", "1"));
                claims.Add(new Claim("product", "2"));

                var claimsIdentity = new ClaimsIdentity(
                            claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity));
                return Redirect("~/Home");
            }

            return View("Index");
        }

    }
}
