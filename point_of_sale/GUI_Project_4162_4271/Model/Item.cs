﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Project_4162_4271.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public double UnitPrice { get; set; }

        public int Unit { get; set; }

        public double TotalPrice { get; set; }
    }
}
