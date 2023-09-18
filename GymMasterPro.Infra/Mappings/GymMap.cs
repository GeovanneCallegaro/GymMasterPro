using GymMasterPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymMasterPro.Infra.Mappings
{
    public class GymMap : IEntityTypeConfiguration<Gym>
    {

        public void Configure(EntityTypeBuilder<Gym> builder)
        {
            builder.ToTable("Gym");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Name.SimpleName)
                .IsRequired()
                .HasColumnName("GymName")
                .HasColumnType("VARCHAR")
                .HasMaxLength(64);

                
        }
    }
}
