using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Data.Entity;

namespace WebApi.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.IsDelete).HasDefaultValue(false);
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            //builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(p => p.CreatedAt).HasDefaultValue(DateTime.UtcNow);
        }
    }
}
