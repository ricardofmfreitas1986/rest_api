using Microsoft.EntityFrameworkCore;
using MedicationRESTApi.Models;

namespace MedicationRESTApi.Context
{
    public class PharmacyDBContext
      : DbContext
    {
        public PharmacyDBContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Medication> Medications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medication>().HasData(
            new Medication() { Id = Guid.NewGuid(), Name = "Aspirina", CreationDate = DateTime.UtcNow, Quantity =2 },
            new Medication() { Id = Guid.NewGuid(), Name = "Voltaren", CreationDate = DateTime.UtcNow, Quantity = 2 }
            );
        }
    }
}
