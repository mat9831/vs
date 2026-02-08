using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerServices _sellerService;
        private readonly WebApplication1Context _context;

        public SellersController(
            SellerServices sellerService,
            WebApplication1Context context)
        {
            _sellerService = sellerService;
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(
                _context.Department.ToList(),
                "Id",
                "Name"
            );

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = new SelectList(
                    _context.Department.ToList(),
                    "Id",
                    "Name"
                );

                return View(seller);
            }

            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

    }
}

