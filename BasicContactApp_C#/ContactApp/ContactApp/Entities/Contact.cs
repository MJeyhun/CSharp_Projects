﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public bool isDeleted { get; set; }
        public string FullName { get; set; }
        public string Number { get; set; }
    }
}
