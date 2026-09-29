using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LostAndFound.Api.Features.Items;

public sealed class FoundItemConfiguration : IEntityTypeConfiguration<FoundItem>
{
    public void Configure(EntityTypeBuilder<FoundItem> builder)
    {
        builder.ToTable("found_items");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserFoundId).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(1024).IsRequired();
        builder.Property(x => x.Cabinet).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Category).HasConversion<int>().IsRequired();
        builder.Property(x => x.Status).HasConversion<int>().IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.FoundAt).IsRequired();
        builder.Property(x => x.PhotoKey).HasMaxLength(500);
        builder.HasIndex(x => x.UserFoundId);
        builder.HasIndex(x => new
        {
            x.Status,
            x.Category,
            x.CreatedAt
        });
    }
}