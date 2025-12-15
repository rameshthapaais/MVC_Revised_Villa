using Microsoft.AspNetCore.Mvc;
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
    }
}
