using Microsoft.AspNetCore.Mvc;
using Villa.Domain.Entities;
using Villa.Infrastructure.Data;

namespace Villa_Again_MVC.Controllers
{

    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VillaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var villas = _context.Villas.ToList();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villia obj)
        {
            if (obj.Name == obj.Location || obj.Name == obj.Description)
            {
                ModelState.AddModelError("", "The text cannot be the same as the name.");
            }
            if (ModelState.IsValid)
            {
                _context.Villas.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Edit(int id)
        {   
            
            var villaFromDb = _context.Villas.Find(id);
            if (villaFromDb == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Villia obj)
        {
            if (obj.Name == obj.Location || obj.Name == obj.Description)
            {
                ModelState.AddModelError("", "The text cannot be the same as the name.");
            }
            if (ModelState.IsValid)
            {
                _context.Villas.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Villa updated successfully";
                return RedirectToAction("Index");
               
            }
            TempData["error"] = "Error while updating villa";
            return View(obj);
        }

        
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            var VillaFromDb = _context.Villas.FirstOrDefault(u=>u.Id == id);
            return View(VillaFromDb);
        }

        [HttpPost]
        public IActionResult Delete(Villia obj)
        {
            var VillaFromDb = _context.Villas.FirstOrDefault(u => u.Id == obj.Id);

            if (VillaFromDb is not null)
            {
                _context.Villas.Remove(VillaFromDb);
                _context.SaveChanges();
                TempData["success"] = "Villa deleted successfully";
                return RedirectToAction("Index");

            }
            TempData["error"] = "Error while deleting villa";
            return View(obj);
        }

    }

}
