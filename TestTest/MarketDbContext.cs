using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TestTest.Entity;

namespace TestTest
{
    public class MarketDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public MarketDbContext(DbContextOptions<MarketDbContext> context) : base(context)
        {

        }
        public DbSet<Market> markets { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Personal> personals { get; set; }
        public DbSet<market_protuct> market_Protucts { get; set; }
        public DbSet<User> users { get; set; }   



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Market>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Market>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Market>().Property(x => x.Name).HasMaxLength(20);
            modelBuilder.Entity<Market>().Property(x => x.Description).HasMaxLength(100);

            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(20);

            modelBuilder.Entity<User>().HasKey(x => x.Id);
           
            modelBuilder.Entity<User>().HasOne(x => x.Personal).WithOne().HasForeignKey<User>(x => x.Personal_id);


            modelBuilder.Entity<Personal>().HasKey(x => x.Id);
            modelBuilder.Entity<Personal>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Personal>().Property(x => x.Name).HasMaxLength(30);
            modelBuilder.Entity<Personal>().HasOne(x => x.market).WithMany(x => x.personali)
                .HasForeignKey(x => x.marcetPersonID).IsRequired(false);

            modelBuilder.Entity<market_protuct>().HasKey(x => new { x.productID, x.MarketID });
            modelBuilder.Entity<market_protuct>().HasOne(x => x.product).WithMany(x => x.marketi_producti)
                .HasForeignKey(x => x.productID);
            modelBuilder.Entity<market_protuct>().HasOne(x=> x.market).WithMany(z=> z.nmarket_product)
                .HasForeignKey(x=> x.MarketID);





        }
    }
}