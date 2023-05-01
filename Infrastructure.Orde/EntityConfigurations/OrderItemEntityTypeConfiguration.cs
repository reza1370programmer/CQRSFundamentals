

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Infrastructure.Orde.EntityConfigurations
{
    class OrderItemEntityTypeConfiguration
: IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem>
        orderItemConfiguration)
        {
            orderItemConfiguration.ToTable("OrderItems", OrderingContext.DEFAULT_SCHEMA);
            orderItemConfiguration.HasKey(o => o.Id);
            orderItemConfiguration.Property(o => o.Id).UseHiLo("orderitemseq");
            orderItemConfiguration.Property(o => o.Id);
            orderItemConfiguration.Property<decimal>("_discount").HasColumnType("decimal(18,2)").IsRequired();
            orderItemConfiguration.Property<int>("ProductId").IsRequired();
            orderItemConfiguration.Property<string>("_productName").IsRequired();
            orderItemConfiguration.Property<decimal>("_unitPrice").HasColumnType("decimal(18,2)").IsRequired();
            orderItemConfiguration.Property<int>("_units").IsRequired();
            orderItemConfiguration.Property<string>("_pictureUrl").IsRequired(false);
            orderItemConfiguration.HasOne(p => p._order).WithMany(p => p.OrderItems).HasForeignKey(o => o._orderId).IsRequired();
            orderItemConfiguration.Ignore(b => b.DomainEvents);

        }
    }

}
