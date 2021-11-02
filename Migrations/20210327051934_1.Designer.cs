﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project_final_6013532.Data;

namespace project_final_6013532.Migrations
{
    [DbContext(typeof(rejectAtsDbContext))]
    [Migration("20210327051934_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("project_final_6013532.ClientData", b =>
                {
                    b.Property<string>("clientDataId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("mktId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("mktName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("surname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("telNo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("clientDataId");

                    b.ToTable("clientdata");
                });

            modelBuilder.Entity("project_final_6013532.RejectAts", b =>
                {
                    b.Property<int>("rejectAtsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("amount")
                        .HasColumnType("double");

                    b.Property<string>("clientDataId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("receivingBank")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("receivingBankNo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("refCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("sendingBank")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("sendingBankNo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("statusCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("statusDescription")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("rejectAtsId");

                    b.HasIndex("clientDataId");

                    b.ToTable("rejectAts");
                });

            modelBuilder.Entity("project_final_6013532.RejectAts", b =>
                {
                    b.HasOne("project_final_6013532.ClientData", "client")
                        .WithMany()
                        .HasForeignKey("clientDataId");
                });
#pragma warning restore 612, 618
        }
    }
}
