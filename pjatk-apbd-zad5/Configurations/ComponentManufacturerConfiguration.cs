using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pjatk_apbd_zad5.Entities;

namespace pjatk_apbd_zad5.Configurations;

public class ComponentManufacturerConfiguration : IEntityTypeConfiguration<ComponentManufacturer>
{
    public void Configure(EntityTypeBuilder<ComponentManufacturer> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Abbreviation).HasMaxLength(30).IsRequired();
        builder.Property(m => m.FullName).HasMaxLength(300).IsRequired();
        builder.Property(m => m.FoundationDate).HasColumnType("date");

        builder.HasData(new List<ComponentManufacturer>()
        {
            new ComponentManufacturer() { Id = 1, Abbreviation = "AMD", FullName = "AMD Corpo", FoundationDate = new DateOnly(1969, 5, 1) },
            new ComponentManufacturer() { Id = 2, Abbreviation = "NV", FullName = "NVIDIA Corporation", FoundationDate = new DateOnly(1993, 4, 5) },
            new ComponentManufacturer() { Id = 3, Abbreviation = "COR", FullName = "Corsair Gaming Inc.", FoundationDate = new DateOnly(1994, 1, 1) }
        });
    }
}
