using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pjatk_apbd_zad5.Entities;

namespace pjatk_apbd_zad5.Configurations;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.HasKey(c => c.Code);
        builder.Property(c => c.Code).HasColumnType("char(10)");
        builder.Property(c => c.Name).HasMaxLength(300).IsRequired();
        builder.Property(c => c.Description).HasColumnType("nvarchar(max)").IsRequired();

        builder.HasOne(c => c.ComponentManufacturer)
            .WithMany(m => m.Components)
            .HasForeignKey(c => c.ComponentManufacturerId);

        builder.HasOne(c => c.ComponentType)
            .WithMany(t => t.Components)
            .HasForeignKey(c => c.ComponentTypeId);

        builder.HasData(new List<Component>()
        {
            new Component() { Code = "CPU0000001", Name = "Ryzen 7", Description = "Gaming processor", ComponentManufacturerId = 1, ComponentTypeId = 1 },
            new Component() { Code = "GPU0000001", Name = "RTX 5090", Description = "Some card dunno", ComponentManufacturerId = 2, ComponentTypeId = 2 },
            new Component() { Code = "RAM0000001", Name = "Corsair DDR5 16GB", Description = "DDR5 RAM", ComponentManufacturerId = 3, ComponentTypeId = 3 }
        });
    }
}
