using System;
using Zaiko.Models;

namespace Zaiko.Services.Products.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static ProductDTO FromModel(Product p) => new ProductDTO
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description
        };
    }
}
