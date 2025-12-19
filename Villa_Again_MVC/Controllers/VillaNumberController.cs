using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Villa.Domain.Entities;
using Villa.Infrastructure.Data;
using Villa_Again_MVC.ViewModel;

namespace Villa_Again_MVC.Controllers
{

    public class VillaNumberController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VillaNumberController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var villaNumbers = _context.VillaNumbers.Include(u => u.Villa).ToList();
            return View(villaNumbers);
        }

        public IActionResult Create()
        {
            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _context.Villas.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };

            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Create(VillaNumberVM obj)
        {

            if (_context.VillaNumbers.Any(u => u.VillaNo == obj.VillaNumber.VillaNo))
            {
                TempData["error"] = "Villa Number already exists in the database";
                //return RedirectToAction("Index", "Home");
                obj.VillaList = _context.Villas.Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                _context.VillaNumbers.Add(obj.VillaNumber);
                _context.SaveChanges();
                TempData["success"] = "Villa Number created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Edit(int id)
        {

            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _context.Villas.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                VillaNumber = _context.VillaNumbers.FirstOrDefault(u => u.VillaNo == id)



            };

            if (villaNumberVM.VillaNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Edit(VillaNumberVM obj)
        {
            if (obj?.VillaNumber == null)
            {
                TempData["error"] = "Invalid delete request";
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                _context.VillaNumbers.Update(obj.VillaNumber);
                _context.SaveChanges();
                TempData["success"] = "Villa Number updated successfully";
                return RedirectToAction("Index");

            }
            TempData["error"] = "Error while updating villa Number";
            return View(obj);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            var VillaNumberFromDb = _context.VillaNumbers.FirstOrDefault(u => u.VillaNo == id);
            VillaNumberVM villaNumberVM = new()
            {
                VillaNumber = VillaNumberFromDb
            };
            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Delete(VillaNumberVM obj)
        {
            if (obj?.VillaNumber == null)
            {
                TempData["error"] = "Invalid delete request";
                return RedirectToAction("Index");
            }
            var villaNumberFromDb = _context.VillaNumbers.FirstOrDefault(u => u.VillaNo ==obj.VillaNumber.VillaNo);

            if (villaNumberFromDb == null)
            {
                TempData["error"] = "Villa number not found";
                return RedirectToAction("Index");
            }

            
            _context.VillaNumbers.Remove(villaNumberFromDb);
            _context.SaveChanges();
            TempData["success"] = "Villa Number deleted successfully";
            return RedirectToAction("Index");
            
        }

    }

}
