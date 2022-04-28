
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class ERPDbContext : IdentityDbContext
    {
        public ERPDbContext(DbContextOptions<ERPDbContext> options)
            : base(options)
        {

        }

        
        public  DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var produto = builder.Entity<Produto>();
            produto.Property(n => n.Price).HasPrecision(5, 2);
            produto.Property(n => n.Total).HasPrecision(6, 2);

        }
    }
}