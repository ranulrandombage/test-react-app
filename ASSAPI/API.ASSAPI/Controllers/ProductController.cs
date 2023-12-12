using Interfaces.ASSAPI.Interfaces;
using Mappers.ASSAPI.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.ASSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private IProductService _productService;

        public ProductController(IProductService productService) {
            _productService = productService;
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductDTO product)
        {
            ResponseDTO result = new();
        
            result = await _productService.AddProduct(product);
            if (result == null)
            {
                result.Message = "Unauthorized";
                return Unauthorized(result);
            }
            if (result != null && result.ErrorMessage != null)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }
        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductDTO product)
        {
            ResponseDTO result = new();

            result = await _productService.UpdateProduct(product);
            if (result == null)
            {
                result.Message = "Unauthorized";
                return Unauthorized(result);
            }
            if (result != null && result.ErrorMessage != null)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            ResponseDTO result = new();

            result = await _productService.GetAll();
            if (result == null)
            {
                result.Message = "Unauthorized";
                return Unauthorized(result);
            }
            if (result != null && result.ErrorMessage != null)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }
    }
}
