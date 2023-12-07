using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATEC_BOOK_LENDING.Controllers
{
    public class Add : Controller
    {
        // GET: Add
        public ActionResult Index()
        {
            return View();
        }

        // GET: Add/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Add/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Add/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Add/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Add/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Add/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Add/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
