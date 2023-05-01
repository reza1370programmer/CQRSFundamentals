
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Infrastructure.Orde.EntityConfigurations
{
    class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> orderConfiguration)
        {
            orderConfiguration.ToTable("Orders", OrderingContext.DEFAULT_SCHEMA);
            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).UseHiLo("orderseq", OrderingContext.DEFAULT_SCHEMA);
            orderConfiguration.OwnsOne(o => o.Address, a =>
            {
                a.WithOwner();
            });
            orderConfiguration.Property(p => p._buyerId).IsRequired(false);
            orderConfiguration.Property<DateTime>("_orderDate").IsRequired();
            orderConfiguration.Property<int>("_orderStatusId").IsRequired();
            orderConfiguration.Property<string>("Description").IsRequired(false);
            orderConfiguration.HasOne(p => p._buyer).WithMany(p => p.Orders).IsRequired(false).HasForeignKey(p => p._buyerId);
            orderConfiguration.HasOne(o => o.OrderStatus).WithMany().HasForeignKey("_orderStatusId");
            orderConfiguration.Ignore(b => b.DomainEvents);

        }
    }
}
