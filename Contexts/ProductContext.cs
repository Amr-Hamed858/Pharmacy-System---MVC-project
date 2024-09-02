using Day_6.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_6.Contexts
{
	public class ProductContext : DbContext
	{

		public virtual DbSet<Drug> Drugs { get; set; }
		public virtual DbSet<Company> Companies { get; set; }

        public ProductContext(DbContextOptions options):base(options) 
        {
            
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Drug>(d =>
			{
				d.HasKey(d => d.ID);

				d.HasOne(d => d.Company)
				 .WithMany(C => C.Drugs)
				 .HasForeignKey(d => d.CompanyID);
				d.Property(d => d.Name).HasMaxLength(50);
			});


			modelBuilder.Entity<Company>(C =>
			{
				C.HasKey(C => C.ID);
				C.Property(C => C.Name).HasMaxLength(20);
			});

			base.OnModelCreating(modelBuilder);
		}
	}
}
