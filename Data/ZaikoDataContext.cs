using Microsoft.EntityFrameworkCore;
using Zaiko.Models;

namespace Zaiko.Data
{
    public class ZaikoDataContext : DbContext
    {
        public ZaikoDataContext(DbContextOptions<ZaikoDataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder.UseInMemoryDatabase("ZaikoDB");

        public DbSet<Product> ProductList { get; private set; }
        public DbSet<Sheet> SheetDbSet { get; private set; }
    }
}