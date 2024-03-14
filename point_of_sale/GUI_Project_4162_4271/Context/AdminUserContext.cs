using GUI_Project_4162_4271.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Project_4162_4271.Context
{
    public class AdminUserContext : DbContext
    {
        public DbSet<AdminUser> AdminUsers { get; set; }
        private readonly string _path = @"H:\Ruh_eng_2020\Academic\semester3\gui\asignmnt\point_of_sale\GUI_Project_4162_4271\AdminUsers.db";

        protected override void
            OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data source={_path}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminUser>().HasData(
                new AdminUser
                {

                    AdminId = 1,
                    AdminUserName = "admin",
                    AdminUserPassword = 4162,
                    UserType = UserType.Admin
                }
            );
            modelBuilder.Entity<AdminUser>().HasKey(n => n.AdminId);




        }

    }
}
