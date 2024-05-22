﻿// <auto-generated />
using System;
using CitiesManager.WebAPI.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CitiesManager.WebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240520114125_CityNameRequired")]
    partial class CityNameRequired
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CitiesManager.WebAPI.Models.City", b =>
                {
                    b.Property<Guid>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityID");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityID = new Guid("e9ee9609-7788-44d9-9995-c2b4f5c4c37e"),
                            CityName = "New York"
                        },
                        new
                        {
                            CityID = new Guid("a215caf4-ba01-415a-a5a1-9cc4d7a1ddd6"),
                            CityName = "London"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
