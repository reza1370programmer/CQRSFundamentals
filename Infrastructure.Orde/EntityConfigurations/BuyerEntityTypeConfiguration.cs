﻿

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.AggregatesModel.BuyerAggregate;

namespace Infrastructure.Orde.EntityConfigurations
{
    public class BuyerEntityTypeConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> buyerConfiguration)
        {
            buyerConfiguration.ToTable("Buyers",OrderingContext.DEFAULT_SCHEMA);
            buyerConfiguration.HasKey(b => b.Id);

            buyerConfiguration.Property(b => b.Id).UseHiLo("buyerseq", OrderingContext.DEFAULT_SCHEMA);
            buyerConfiguration.Property(b => b.IdentityGuid).HasMaxLength(200).IsRequired();
            buyerConfiguration.HasIndex("IdentityGuid").IsUnique(true);
            buyerConfiguration.Property(b => b.Name);
            buyerConfiguration.Ignore(b => b.DomainEvents);
        }

    }
}
