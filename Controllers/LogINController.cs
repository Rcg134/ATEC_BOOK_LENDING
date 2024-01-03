using ATEC_BOOK_LENDING.Context;
using Microsoft.AspNetCore.Mvc;
using ATEC_BOOK_LENDING.Model.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace ATEC_BOOK_LENDING.Controllers
{
    public class LogINController : Controller
    {
        private readonly LoginContext _loginContext;

        public LogINController(LoginContext loginContext)
        {
            _loginContext = loginContext;
        }
        //[Route("/Login")]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(User usr)
        {
            var isExist = await _loginContext
                .Users
                .AnyAsync(x => x.Username == usr.Username && x.Password == usr.Password);


            if (!isExist && usr.Username != null && usr.Password != null)
            {
                ModelState.AddModelError(string.Empty, "UserName or Password is invalid");
            }



            if (ModelState.IsValid && isExist)
            {
                List<Claim> claims = new List<Claim>(){
                     new Claim(ClaimTypes.NameIdentifier,usr.Username),
                      new Claim(ClaimTypes.Role, "Admin")
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));


                return RedirectToAction("Index", "Home", new { page = 1 });
            }


           return View(usr);
        }
    }
}
