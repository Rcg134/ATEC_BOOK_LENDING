using ATEC_BOOK_LENDING.Context;
using ATEC_BOOK_LENDING.DTO;
using ATEC_BOOK_LENDING.Model;
using ATEC_BOOK_LENDING.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ATEC_BOOK_LENDING.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookContext _bookContext;

        public HomeController(ILogger<HomeController> logger , BookContext bookContext)
        {
            _logger = logger;
            _bookContext = bookContext;
        }
        [HttpGet]
        public async Task<IActionResult>Index()
        {

            var UserDTO = await _bookContext.Users.Select( x => new UserDTO
            {
               UserId = x.UserId,
               Name = x.Name,
               MiddleName = x.MiddleName,
               Surname = x.Surname,
               Active = x.Active,
            }).ToListAsync();
            return View(UserDTO);
        }


        [HttpGet]
        public ActionResult Add()
        {


            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(User addUser)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    addUser.Active = true;
                    addUser.CreatedDate = DateTime.Now;
                    _bookContext.Users.Add(addUser);
                    await _bookContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(addUser);

            }
            catch (Exception ex)
            {
                return View(addUser);
            }
            

        }

       [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var getDetails = await _bookContext.Users.SingleOrDefaultAsync(x => x.UserId == id);
            return View(getDetails);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, User editUser)
        {

            try
            {
                var getDetails = await _bookContext.Users.SingleOrDefaultAsync(x => x.UserId == id);

                if (ModelState.IsValid && getDetails != null)
                {
                    getDetails.Name = editUser.Name;
                    getDetails.MiddleName = editUser.MiddleName;
                    getDetails.Surname = editUser.Surname;
                    await _bookContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Null");
                return View(editUser);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.ToString());
                return View(editUser);
            }
        }


        public  async Task<ActionResult> Delete(int id)
        {
            var UserDetails = await _bookContext.Users.SingleOrDefaultAsync(x => x.UserId == id);  

            return PartialView("_DeleteUser", UserDetails);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(User usr)
        {

            try
            {
                var getDetails = await _bookContext.Users.SingleOrDefaultAsync(x => x.UserId == usr.UserId);

                if (getDetails != null)
                {
                    _bookContext.Users.Remove(getDetails);
                    _bookContext.SaveChanges();
                }

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.ToString());
                return RedirectToAction("Index");
            }
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}