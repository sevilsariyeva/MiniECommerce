﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(MarketDbContext))]
    partial class MarketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Jane",
                            Surname = "Johnson"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mike",
                            Surname = "Black"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Lisa",
                            Surname = "Kudrow"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Monica",
                            Surname = "Geller"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Daniel",
                            Surname = "Ronald"
                        });
                });

            modelBuilder.Entity("WebApplication1.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            OrderDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            OrderDate = new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 2
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 3,
                            OrderDate = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 3
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 4,
                            OrderDate = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 4
                        },
                        new
                        {
                            Id = 5,
                            CustomerId = 5,
                            OrderDate = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 5
                        });
                });

            modelBuilder.Entity("WebApplication1.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Discount = 15.0,
                            Name = "T-Shirt",
                            Price = 59.0
                        },
                        new
                        {
                            Id = 2,
                            Discount = 25.0,
                            Name = "Trousers",
                            Price = 119.0
                        },
                        new
                        {
                            Id = 3,
                            Discount = 5.0,
                            Name = "Shirt",
                            Price = 89.0
                        },
                        new
                        {
                            Id = 4,
                            Discount = 35.0,
                            Name = "Blouse",
                            Price = 69.0
                        },
                        new
                        {
                            Id = 5,
                            Discount = 45.0,
                            Name = "Short",
                            Price = 79.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
