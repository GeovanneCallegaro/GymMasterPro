using GymMasterPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymMasterPro.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Gym> Gyms { get; set; }
        public DbSet<GymOwner> GymOwners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}
