using GeekShopping.ProductApi.Repository;
using GeekShopping.ProductApi.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> GetAll()
        {
            var products = await _productRepository.GetAll();

            if(products == null) return NotFound("Nenhum produto encontrado");

            return Ok(products);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<ProductVO>> GetById(long id)
        {
            if (id == 0) return BadRequest("Identificador inválido!");
            var product = await _productRepository.GetById(id);
            if (product == null) return NotFound("Produto não encontrado!");

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create([FromBody]ProductVO product)
        {
            if (product == null) return BadRequest("Objeto inválido!");

            var _product = await _productRepository.Create(product);

            return Ok(_product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update([FromBody]ProductVO product)
        {
            if (product == null) return BadRequest("Objeto inválido!");

            var _product = await _productRepository.Update(product);

            return Ok(_product);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _productRepository.Delete(id);

            if (status == false) return NotFound("Nenhum produto encontrado");

            return Ok(status);
        }
    }
}
