using System;
using Zaiko.Models;

namespace Zaiko.Services.ProductListEntries.DTO
{
    public record ProductListEntryDTO
    {
        public Guid ProductId;
        public int Quantity;

        public ProductListEntryDTO(ProductListEntry entry)
        {
            ProductId = entry.Product.Id;
            Quantity = entry.Quantity;
        }
    }
}
