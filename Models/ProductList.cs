using System.Collections.Generic;

namespace Zaiko.Models
{
    public abstract class ProductList
    {
        public abstract void SetProductQuantity(Product p, int quantity);

        public void RemoveProduct(Product p)
        {
            SetProductQuantity(p, 0);
        }

        public abstract int GetProductQuantity(Product p);

        public abstract IEnumerable<ProductListEntry> GetProductList();
    }
}