using System;
using System.Collections.Generic;
using System.Linq;

namespace Zaiko.Models
{
    public class Sheet : ProductList
    {
        public Guid Id { get; private set; }

        public string Name { get; set; }
        private IList<ProductListEntry> Entries;

        public Sheet(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Entries = new List<ProductListEntry>();
        }
 
        public override int GetProductQuantity(Product p)
        {
            var entry = Entries.Where(e => e.Product.Id == p.Id).FirstOrDefault(null);
            return entry is null ? 0 : entry.Quantity;
        }

        public override void SetProductQuantity(Product p, int quantity)
        {
            var entry = Entries.Where(e => e.Product.Id == p.Id).FirstOrDefault(null);
            if (entry is null) Entries.Add(new ProductListEntry(p, quantity));
            else entry.Quantity = quantity;
        }

        public override IEnumerable<ProductListEntry> GetProductList()
        {
            return Entries.ToArray();
        }
    }
}