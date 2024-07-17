using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rira.Domain.CustomerAgg;

namespace Rira.Infrastructure.EFCore.Mapping
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("CustomersTb");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Family).HasMaxLength(255).IsRequired();
            builder.Property(x => x.NationalNumber).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Birthday).HasMaxLength(255).IsRequired();

        }
    }
}