using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerServices _sellerService;

        public SellersController (SellerServices sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var List = _sellerService.FindAll();

            return View(List);
        }
    }
}
