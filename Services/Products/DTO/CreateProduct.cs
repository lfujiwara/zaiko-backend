namespace Zaiko.Services.Products.DTO
{
    public record CreateProduct
    {
        public string Name { get; init; }

        public string Description { get; init; }
    }
}