﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PicPayApiChallenge.Data.Context;

#nullable disable

namespace PicPayApiChallenge.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230826184719_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PicPayApiChallenge.Domain.Models.ClientEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("unique");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("unique");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("PicPayApiChallenge.Domain.Models.ShopKeeperEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("unique");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("unique");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("shopkeepers", (string)null);
                });

            modelBuilder.Entity("PicPayApiChallenge.Domain.Models.TransactionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal?>("Amount")
                        .IsRequired()
                        .HasColumnType("decimal");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ShopkeeperId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ShopkeeperId");

                    b.ToTable("transactions", (string)null);
                });

            modelBuilder.Entity("PicPayApiChallenge.Domain.Models.TransactionEntity", b =>
                {
                    b.HasOne("PicPayApiChallenge.Domain.Models.ClientEntity", "Client")
                        .WithMany("Transactions")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PicPayApiChallenge.Domain.Models.ShopKeeperEntity", "Shopkeeper")
                        .WithMany("Transactions")
                        .HasForeignKey("ShopkeeperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Shopkeeper");
                });

            modelBuilder.Entity("PicPayApiChallenge.Domain.Models.ClientEntity", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("PicPayApiChallenge.Domain.Models.ShopKeeperEntity", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
