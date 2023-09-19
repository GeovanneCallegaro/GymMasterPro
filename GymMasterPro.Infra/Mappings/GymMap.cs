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
                .HasColumnName("Name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(64);

            builder.Property(x => x.Address.Street)
                .IsRequired()
                .HasColumnName("Street")
                .HasColumnType("VARCHAR")
                .HasMaxLength(128);

            builder.Property(x => x.Address.Number)
                .IsRequired()
                .HasColumnName("Number")
                .HasColumnType("VARCHAR")
                .HasMaxLength(8);

            builder.Property(x => x.Address.Neighborhood)
                .IsRequired()
                .HasColumnName("Neighborhood")
                .HasColumnType("VARCHAR")
                .HasMaxLength(32);

            builder.Property(x => x.Address.City)
                .IsRequired()
                .HasColumnName("City")
                .HasColumnType("VARCHAR")
                .HasMaxLength(32);

            builder.Property(x => x.Address.Country)
                .IsRequired()
                .HasColumnName("Country")
                .HasColumnType("VARCHAR")
                .HasMaxLength(32);

            builder.HasOne(x => x.Owner)
                .WithMany(x => x.Gyms)
                .HasConstraintName("FK_GYM_OWNER")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
