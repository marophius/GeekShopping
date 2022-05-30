using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;


        public ProductController(IProductService service)
        {
            _service = service ??throw new ArgumentNullException(nameof(service));
        }
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductIndex()
        {
            var products = await _service.GetAll();
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel product)
        {
            if(ModelState.IsValid)
            {
               var result = _service.Create(product);
                if(result != null)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(product);
        }

        public async Task<IActionResult> ProductUpdate(long id)
        {
            var product = await _service.GetById(id);
            if(product != null)
            {
                return View(product);
            }

            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var result = _service.Update(product);
                if (result != null)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(product);
        }

        [Authorize]
        public async Task<IActionResult> ProductDelete(long id)
        {
            var model = await _service.GetById(id);
            if(model != null) return View(model);
            return NotFound();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductModel _product)
        {
            var product = await _service.Delete(_product.Id);
            if (product) return RedirectToAction(nameof(ProductIndex));

            return View();
        }
    }
}
