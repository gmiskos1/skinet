using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{

      [ApiController]
      [Route("api/[controller]")]
      public class ProductsController : ControllerBase
      {
            private readonly IProductRepository _repo;
            private readonly IProductBrandRepository _repoBrand;
            private readonly IProductTypeRepository _repoType;
            public ProductsController(IProductRepository repo, IProductBrandRepository repoBrand, IProductTypeRepository repoType)
            {                  
                  _repo = repo;
                  _repoBrand = repoBrand;
                  _repoType = repoType;
            }

            [HttpGet]
            public async Task<ActionResult<List<Product>>> GetProducts()
            {
                  var products = await _repo.GetProductsAsync();

                  return Ok(products);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Product>> GetProduct(int id)
            {
                  return await _repo.GetProductByIdAsync(id);
            }

            [HttpGet("brands")]
            public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
            {
                  return Ok(await _repoBrand.GetProductBrandsAsync());
            }

            [HttpGet("types")]
            public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
            {
                  return Ok(await _repoType.GetProductTypesAsync());
            }
      }
}