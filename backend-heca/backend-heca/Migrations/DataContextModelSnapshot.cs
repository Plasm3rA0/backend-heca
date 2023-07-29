﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend_heca.Data;

#nullable disable

namespace backend_heca.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("backend_heca.Models.Parada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RutaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RutaId");

                    b.ToTable("Parada");
                });

            modelBuilder.Entity("backend_heca.Models.Ruta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ruta");
                });

            modelBuilder.Entity("backend_heca.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("trainIdId")
                        .HasColumnType("int");

                    b.Property<int>("userIdId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("trainIdId");

                    b.HasIndex("userIdId");

                    b.ToTable("Tikets");
                });

            modelBuilder.Entity("backend_heca.Models.Train", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("rutaId")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("rutaId");

                    b.ToTable("Trains");
                });

            modelBuilder.Entity("backend_heca.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("backend_heca.Models.Parada", b =>
                {
                    b.HasOne("backend_heca.Models.Ruta", null)
                        .WithMany("paradas")
                        .HasForeignKey("RutaId");
                });

            modelBuilder.Entity("backend_heca.Models.Ticket", b =>
                {
                    b.HasOne("backend_heca.Models.Train", "trainId")
                        .WithMany()
                        .HasForeignKey("trainIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend_heca.Models.User", "userId")
                        .WithMany()
                        .HasForeignKey("userIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("trainId");

                    b.Navigation("userId");
                });

            modelBuilder.Entity("backend_heca.Models.Train", b =>
                {
                    b.HasOne("backend_heca.Models.Ruta", "ruta")
                        .WithMany()
                        .HasForeignKey("rutaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ruta");
                });

            modelBuilder.Entity("backend_heca.Models.Ruta", b =>
                {
                    b.Navigation("paradas");
                });
#pragma warning restore 612, 618
        }
    }
}
