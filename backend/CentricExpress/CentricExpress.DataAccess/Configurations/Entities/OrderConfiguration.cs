﻿using System.Numerics;
using CentricExpress.Business.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentricExpress.DataAccess.Configurations.Entities
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Date).IsRequired();

            builder.Property(o => o.CustomerId);

            builder.HasMany(o => o.OrderLines).WithOne().OnDelete(DeleteBehavior.Restrict);
        }
    }
}