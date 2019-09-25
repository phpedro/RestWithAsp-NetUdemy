﻿using RestWithAspNetUdemy.Models.Base;
using System;

namespace RestWithAspNetUdemy.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
