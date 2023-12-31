﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayApiChallenge.Domain.Models;

namespace PicPayApiChallenge.Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.Type).IsRequired().HasColumnType("varchar(10)");
            builder.Property(x => x.CPF).IsRequired().HasColumnType("varchar(14)");
            builder.Property(x => x.CNPJ).HasColumnType("varchar(18)");
            builder.Property(x => x.Password).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.Balance).IsRequired().HasColumnType("money");
            builder.Property(x => x.CreatedAt).IsRequired().HasColumnType("date");
            builder.Property(x => x.UpdatedAt).IsRequired(false).HasColumnType("date");
            builder.Property(x => x.DeletedAt).IsRequired(false).HasColumnType("date");

            //Unique fields
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.CPF).IsUnique();
            builder.HasIndex(x => x.CNPJ).IsUnique();

            builder.ToTable("users");
        }
    }
}