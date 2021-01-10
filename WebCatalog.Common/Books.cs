﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCatalog.Common
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
    }
}
