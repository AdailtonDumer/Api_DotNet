using Backend.Data.Map;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    //Para o ideal funcionamento, crie uma migration e excute para o seu banco de dados funcionar corretamente
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
        }
    }
}
