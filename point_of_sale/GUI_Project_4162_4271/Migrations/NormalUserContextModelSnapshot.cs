﻿// <auto-generated />
using GUI_Project_4162_4271.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GUI_Project_4162_4271.Migrations
{
    [DbContext(typeof(NormalUserContext))]
    partial class NormalUserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("GUI_Project_4162_4271.Model.NormalUser", b =>
                {
                    b.Property<int>("NormalUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NormalUserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NormalUserPassword")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserType")
                        .HasColumnType("INTEGER");

                    b.HasKey("NormalUserId");

                    b.ToTable("NormalUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
