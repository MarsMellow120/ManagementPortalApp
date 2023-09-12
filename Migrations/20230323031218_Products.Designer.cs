﻿// <auto-generated />
using System;
using ManagementPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManagementPortal.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20230323031218_Products")]
    partial class Products
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ManagementPortal.Models.Department", b =>
                {
                    b.Property<string>("DepartmentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentID = "AD",
                            DepartmentName = "Administration"
                        },
                        new
                        {
                            DepartmentID = "AC",
                            DepartmentName = "Accounting"
                        },
                        new
                        {
                            DepartmentID = "IT",
                            DepartmentName = "Information Technology"
                        },
                        new
                        {
                            DepartmentID = "CS",
                            DepartmentName = "Customer Service"
                        },
                        new
                        {
                            DepartmentID = "SA",
                            DepartmentName = "Sales"
                        },
                        new
                        {
                            DepartmentID = "OP",
                            DepartmentName = "Operations"
                        });
                });

            modelBuilder.Entity("ManagementPortal.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DepartmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Hours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PayRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = "AD",
                            Hours = 40m,
                            Name = "Luke Skywalker",
                            PayRate = 30m,
                            StartDate = new DateTime(2010, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Human Resources Manager"
                        },
                        new
                        {
                            Id = 2,
                            DepartmentId = "AC",
                            Hours = 40m,
                            Name = "Leia Organa",
                            PayRate = 18m,
                            StartDate = new DateTime(2007, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Junior Accountant"
                        },
                        new
                        {
                            Id = 3,
                            DepartmentId = "SA",
                            Hours = 35m,
                            Name = "Ezra Bridger",
                            PayRate = 22m,
                            StartDate = new DateTime(2018, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Sales Associate"
                        });
                });

            modelBuilder.Entity("ManagementPortal.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Laser sword useful for cutting objects",
                            Inventory = 42,
                            Name = "LightSaber",
                            Price = 29.99m
                        });
                });

            modelBuilder.Entity("ManagementPortal.Models.Employee", b =>
                {
                    b.HasOne("ManagementPortal.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
