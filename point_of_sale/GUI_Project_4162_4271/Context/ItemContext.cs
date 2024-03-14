using GUI_Project_4162_4271.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Project_4162_4271.Context
{
    public class ItemContext : DbContext
    {
        public DbSet<Item>Items { get; set; }
        public object Products { get; internal set; }

        private readonly string path = @"H:\Ruh_eng_2020\Academic\semester3\gui\asignmnt\point_of_sale\GUI_Project_4162_4271\Items.db";

        protected override void
            OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data source={path}");

    }
}
