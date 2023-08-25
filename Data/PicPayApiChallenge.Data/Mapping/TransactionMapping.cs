﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PicPayApiChallenge.Domain.Models;

namespace PicPayApiChallenge.Data.Mapping
{
    public class TransactionMapping : IEntityTypeConfiguration<TransactionEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Amount).IsRequired().HasColumnType("decimal");
            builder.Property(x => x.Date).IsRequired().HasColumnType("date");
            builder.HasOne(x => x.Client).WithMany(x => x.Transactions).IsRequired();
            builder.Property(x => x.ClientId).IsRequired();
            builder.HasOne(x => x.Shopkeeper).WithMany(x => x.Transactions).IsRequired();
            builder.Property(x => x.ShopkeeperId).IsRequired();

            builder.ToTable("transactions");
        }
    }
}