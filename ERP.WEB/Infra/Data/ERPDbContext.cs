

using Domain.Entities;
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

        
        public  DbSet<Compra> Compras { get; set; }
        public DbSet<Consumo> Consumos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Compras
            var compra = builder.Entity<Compra>();
            compra.Property(n => n.Price).HasPrecision(11, 2);
            compra.Property(n => n.Total).HasPrecision(11, 2);


            //Consumo
            var consumo = builder.Entity<Consumo>();

        }
    }
}