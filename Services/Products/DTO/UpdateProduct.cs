using System;

namespace Zaiko.Services.Products.DTO
{
    public record UpdateProduct
    {
        public Guid Id { get; set; }

        public string Name { get; init; }

        public string Description { get; init; }
    }
}