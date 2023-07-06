﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestTest;

#nullable disable

namespace TestTest.Migrations
{
    [DbContext(typeof(MarketDbContext))]
    [Migration("20230705123816_udaitepasworded")]
    partial class udaitepasworded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestTest.Entity.Market", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("markets");
                });

            modelBuilder.Entity("TestTest.Entity.Personal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("marcetPersonID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("marcetPersonID");

                    b.ToTable("personals");
                });

            modelBuilder.Entity("TestTest.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("TestTest.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Personal_id")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Personal_id")
                        .IsUnique();

                    b.ToTable("users");
                });

            modelBuilder.Entity("TestTest.Entity.market_protuct", b =>
                {
                    b.Property<int>("productID")
                        .HasColumnType("int");

                    b.Property<int>("MarketID")
                        .HasColumnType("int");

                    b.HasKey("productID", "MarketID");

                    b.HasIndex("MarketID");

                    b.ToTable("market_Protucts");
                });

            modelBuilder.Entity("TestTest.Entity.Personal", b =>
                {
                    b.HasOne("TestTest.Entity.Market", "market")
                        .WithMany("personali")
                        .HasForeignKey("marcetPersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("market");
                });

            modelBuilder.Entity("TestTest.Entity.User", b =>
                {
                    b.HasOne("TestTest.Entity.Personal", "Personal")
                        .WithOne("User")
                        .HasForeignKey("TestTest.Entity.User", "Personal_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personal");
                });

            modelBuilder.Entity("TestTest.Entity.market_protuct", b =>
                {
                    b.HasOne("TestTest.Entity.Market", "market")
                        .WithMany("nmarket_product")
                        .HasForeignKey("MarketID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestTest.Entity.Product", "product")
                        .WithMany("marketi_producti")
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("market");

                    b.Navigation("product");
                });

            modelBuilder.Entity("TestTest.Entity.Market", b =>
                {
                    b.Navigation("nmarket_product");

                    b.Navigation("personali");
                });

            modelBuilder.Entity("TestTest.Entity.Personal", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("TestTest.Entity.Product", b =>
                {
                    b.Navigation("marketi_producti");
                });
#pragma warning restore 612, 618
        }
    }
}
