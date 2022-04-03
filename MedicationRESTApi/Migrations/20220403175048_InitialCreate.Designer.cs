﻿// <auto-generated />
using System;
using MedicationRESTApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedicationRESTApi.Migrations
{
    [DbContext(typeof(PharmacyDBContext))]
    [Migration("20220403175048_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("MedicationRESTApi.Models.Medication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Medication");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1a3d7301-c1e1-4650-ae96-ac83b19a9209"),
                            CreationDate = new DateTime(2022, 4, 3, 17, 50, 47, 925, DateTimeKind.Utc).AddTicks(9003),
                            Name = "Aspirina",
                            Quantity = 2
                        },
                        new
                        {
                            Id = new Guid("90ba61b2-fff4-48f0-b260-3588ac0bf808"),
                            CreationDate = new DateTime(2022, 4, 3, 17, 50, 47, 925, DateTimeKind.Utc).AddTicks(9007),
                            Name = "Voltaren",
                            Quantity = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
