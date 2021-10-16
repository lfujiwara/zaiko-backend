namespace Zaiko.Models
{
    public class ProductListEntry
    {
        public Product Product { get; private set; }

        public int Quantity { get; set; }

        public ProductListEntry(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }
    }
}