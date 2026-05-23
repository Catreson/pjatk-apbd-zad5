using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pjatk_apbd_zad5.Entities;

namespace pjatk_apbd_zad5.Configurations;

public class PCConfiguration : IEntityTypeConfiguration<PC>
{
    public void Configure(EntityTypeBuilder<PC> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Weight).HasColumnType("float(5)");

        builder.HasData(new List<PC>()
        {
            new PC()
            {
                Id = 1,
                Name = "Gaming Beast X",
                Weight = 12.5f,
                Warranty = 36,
                CreatedAt = new DateTime(2026, 5, 8, 9, 0, 0),
                Stock = 5
            },
            new PC()
            {
                Id = 2,
                Name = "Office Mini Pro",
                Weight = 4.2f,
                Warranty = 24,
                CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0),
                Stock = 12
            },
            new PC()
            {
                Id = 3,
                Name = "MegaPC Deluxe",
                Weight = 9.9f,
                Warranty = 12,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0),
                Stock = 7
            }
        });
    }
}
