﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay4PowerCustomerCareApp.Core.Models
{
    public class Rating:BaseEntity
    {
        public int Ratings { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
       
    }
}
