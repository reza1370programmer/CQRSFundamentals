﻿

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Infrastructure.Orde.EntityConfigurations
{
    class OrderStatusEntityTypeConfiguration
  : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus>
        orderStatusConfiguration)
        {
            orderStatusConfiguration.ToTable("Orderstatus",OrderingContext.DEFAULT_SCHEMA);
            orderStatusConfiguration.HasKey(o => o.Id);
            orderStatusConfiguration.Property(o => o.Id).HasDefaultValueSql("1").ValueGeneratedNever().IsRequired();
            orderStatusConfiguration.Property(o => o.Name).HasMaxLength(200).IsRequired();
        }
    }
}
