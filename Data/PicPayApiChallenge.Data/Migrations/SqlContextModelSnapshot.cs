﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PicPayApiChallenge.Data.Context;

#nullable disable

namespace PicPayApiChallenge.Data.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PicPayApiChallenge.Domain.Models.TransactionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Amount")
                        .IsRequired()
                        .HasColumnType("decimal");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PayeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("transactions", (string)null);
                });

            modelBuilder.Entity("PicPayApiChallenge.Domain.Models.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Balance")
                        .HasColumnType("money");

                    b.Property<string>("CNPJ")
                        .HasColumnType("varchar(18)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CNPJ")
                        .IsUnique()
                        .HasFilter("[CNPJ] IS NOT NULL");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("PicPayApiChallenge.Domain.Models.TransactionEntity", b =>
                {
                    b.HasOne("PicPayApiChallenge.Domain.Models.UserEntity", null)
                        .WithMany("Transactions")
                        .HasForeignKey("UserEntityId");
                });

            modelBuilder.Entity("PicPayApiChallenge.Domain.Models.UserEntity", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
