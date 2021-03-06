﻿// <auto-generated />
using BrewsofTampa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BrewsofTampa.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190226122853_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BrewsofTampa.Models.Brewery", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BeerAdvocate");

                    b.Property<double>("Lat");

                    b.Property<double>("Lng");

                    b.Property<string>("LogoUrl");

                    b.Property<string>("Name");

                    b.Property<string>("Untapped");

                    b.Property<string>("Website");

                    b.HasKey("ID");

                    b.ToTable("Breweries");
                });
#pragma warning restore 612, 618
        }
    }
}
