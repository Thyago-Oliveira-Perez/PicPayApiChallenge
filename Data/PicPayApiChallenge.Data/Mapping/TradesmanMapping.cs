﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayApiChallenge.Domain.Models;

namespace PicPayApiChallenge.Data.Mapping
{
    public class TradesmanMapping : IEntityTypeConfiguration<TradesmanEntity>
    {
        public void Configure(EntityTypeBuilder<TradesmanEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.CPF).IsRequired().HasColumnType("varchar(11)");
            builder.Property(x => x.CNPJ).IsRequired().HasColumnType("varchar(19)");
            builder.Property(x => x.Password).IsRequired().HasColumnType("varchar(50)");

            //Unique fields
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.CPF).IsUnique();
            builder.HasIndex(x => x.CNPJ).IsUnique();

            builder.ToTable("tradesman");
        }
    }
}