using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;
using WebApplication1.Services;

using WebApplication1.Services;
using WebApplication1.Services.Exceptions;

namespace WebApplication1.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerServices _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerServices sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;

        }

        public async Task <IActionResult> Index()
        {
            var list = await _sellerService.FindAllAsync();
            return View(list);
        }

        public async Task <IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create(SellerFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Departments = await _departmentService.FindAllAsync();
                return View(viewModel);
            }

            await _sellerService.InsertAsync(viewModel.Seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task <IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Provided" });
            }
            var obj = await _sellerService.FindByIDAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found" });
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sellerService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Provided" });
            }
        }

        public async Task <IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Provided" });
            }
            var obj = await _sellerService.FindByIDAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found" });
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Provided" });
            }
            var obj = await _sellerService.FindByIDAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found" });
            }
            List<Department> departments = await _departmentService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel{Seller = obj, Departments = departments};
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var ViewModel = new SellerFormViewModel {Seller = seller, Departments = departments};
                return View(ViewModel);
            }
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Mismatch" });
            }
            try
            {
               await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message});
            }
            
        }
        public IActionResult Error(string message)
        {
            var viewmodel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewmodel);
        }
    }
}

