﻿// <auto-generated />
using GUI_Project_4162_4271.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GUI_Project_4162_4271.Migrations.AdminUser
{
    [DbContext(typeof(AdminUserContext))]
    [Migration("20230717101801_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("GUI_Project_4162_4271.Model.AdminUser", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdminUserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("AdminUserPassword")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserType")
                        .HasColumnType("INTEGER");

                    b.HasKey("AdminId");

                    b.ToTable("AdminUsers");

                    b.HasData(
                        new
                        {
                            AdminId = 1,
                            AdminUserName = "admin",
                            AdminUserPassword = 4162,
                            UserType = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
