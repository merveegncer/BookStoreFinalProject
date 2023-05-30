using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using BookStoreFinalProje.Models;
namespace BookStoreFinalProje.Controllers
{
    public class StartpController : Controller
    {
        public IActionResult Login()
        {
            ClaimsPrincipal claimuser = HttpContext.User;
            if(claimuser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Admin");   
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(Logincs logincs)
        {
            if(logincs.Email=="admin@mail.com" && logincs.Password=="1234")
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, logincs.Email),
                    new Claim("Diğer özellikler","Örnek Rol")

                };
                ClaimsIdentity claimsIdentity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties prop = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = logincs.LoggedStatus
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),prop);
                return RedirectToAction("Index","Admin");
            }
            ViewData["OnayMesaji"] = "Kullanıcı bulunamadı";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
