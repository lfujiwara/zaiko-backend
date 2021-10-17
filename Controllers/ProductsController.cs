using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zaiko.Services;
using Zaiko.Services.Common.DTO;
using Zaiko.Services.Products.DTO;

namespace Zaiko.Controllers
{
    [ApiController]
    [Route("Products")]
    public class ProductsController
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly ProductsService _productsService;

        public ProductsController(ILogger<ProductsController> logger, ProductsService productsService)
        {
            _logger = logger;
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<PagedQueryResponse<ProductDTO>> Get([FromQuery(Name = "name")] string name,
            [FromQuery(Name = "page")] string _page, [FromQuery(Name = "pageSize")] string _pageSize)
        {
            _logger.Log(LogLevel.Debug, name);
            int.TryParse(_page, out var page);
            int.TryParse(_pageSize, out var pageSize);
            var _params = new PagedQueryParams
            {
                Page = page,
                PageSize = pageSize,
            };

            return await _productsService.GetProducts(_params);
        }

        [HttpPost]
        public Task<ProductDTO> Post([FromBody] CreateProduct product)
        {
            return _productsService.CreateProduct(product);
        }

        [HttpPatch("{id}")]
        public Task<ProductDTO> Patch(Guid id, [FromBody] UpdateProduct product)
        {
            product.Id = id;
            return _productsService.UpdateProduct(product);
        }

        [HttpDelete("{id}")]
        public Task Delete(Guid id)
        {
            return _productsService.DeleteProduct(id);
        }
    }
}