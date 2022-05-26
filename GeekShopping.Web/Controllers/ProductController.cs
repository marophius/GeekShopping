using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
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

        public async Task<IActionResult> ProductIndex()
        {
            var products = await _service.GetAll();
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

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
    }
}
