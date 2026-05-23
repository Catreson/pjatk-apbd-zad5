using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pjatk_apbd_zad5.Entities;

namespace pjatk_apbd_zad5.Configurations;

public class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType>
{
    public void Configure(EntityTypeBuilder<ComponentType> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Abbreviation).HasMaxLength(30).IsRequired();
        builder.Property(t => t.Name).HasMaxLength(150).IsRequired();

        builder.HasData(new List<ComponentType>()
        {
            new ComponentType() { Id = 1, Abbreviation = "CPU", Name = "Processor" },
            new ComponentType() { Id = 2, Abbreviation = "GPU", Name = "Graphics Card" },
            new ComponentType() { Id = 3, Abbreviation = "RAM", Name = "Memory" }
        });
    }
}
