using System;
using System.Linq;
using System.Threading.Tasks;
using Zaiko.Data;
using Zaiko.Models;
using Zaiko.Services.Products.DTO;
using Zaiko.Services.Common.DTO;

namespace Zaiko.Services
{
    public class ProductsService
    {
        ZaikoDataContext _context;

        public ProductsService(ZaikoDataContext context)
        {
            _context = context;
        }

        public async Task<ProductDTO> CreateProduct(
            CreateProduct dto
        )
        {
            var p = new Product(dto.Name, dto.Description);
            await this._context.AddAsync(p);
            await this._context.SaveChangesAsync();
            return ProductDTO.FromModel(p);
        }

        public async Task<PagedQueryResponse<ProductDTO>> GetProducts(PagedQueryParams _params)
        {
            var skip = Math.Max((_params.Page - 1) * _params.PageSize, 0);
            var take = Math.Clamp(_params.PageSize, 1, 100);
            var result = await this._context.ProductList.AsQueryable().Skip(skip).Take(take).ToAsyncEnumerable().ToArrayAsync();
            var resultDTO = new PagedQueryResponse<ProductDTO>
            {
                Items = result.Select(x => ProductDTO.FromModel(x)).ToList(),
                Page = _params.Page,
                PageSize = _params.PageSize,
                TotalCount = result.Length
            };
            return resultDTO;
        }


        public async Task<ProductDTO> UpdateProduct(UpdateProduct dto)
        {
            var p = await this._context.ProductList.FindAsync(dto.Id);
            if (p == null)
                throw new Exception("Product not found");

            if (dto.Name != null)
                p.setName(dto.Name);
            if (dto.Description != null)
                p.setDescription(dto.Description);

            await this._context.SaveChangesAsync();
            return ProductDTO.FromModel(p);
        }

        public async Task DeleteProduct(Guid id)
        {
            var p = await this._context.ProductList.FindAsync(id);
            if (p == null)
                throw new Exception("Product not found");

            this._context.ProductList.Remove(p);
            await this._context.SaveChangesAsync();
        }
    }
}

