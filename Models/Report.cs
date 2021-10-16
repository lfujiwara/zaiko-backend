using System;
using System.Linq;
using System.Collections.Generic;

namespace Zaiko.Models
{
    public class Report : ProductList
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public bool IsFrozen { get; private set; }


        private IList<ProductListEntry> Entries;


        public Report(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Entries = new List<ProductListEntry>();
        }


        public override int GetProductQuantity(Product p)
        {
            var entry = Entries.Where(e => e.Product.Id == p.Id).FirstOrDefault(null);
            return entry is null ? 0 : entry.Quantity;
        }

        public override void SetProductQuantity(Product p, int quantity)
        {
            if (IsFrozen) return;
            var entry = Entries.Where(e => e.Product.Id == p.Id).FirstOrDefault(null);
            if (entry is null) Entries.Add(new ProductListEntry(p, quantity));
            else entry.Quantity = quantity;
        }
    }
}