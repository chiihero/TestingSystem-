﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework6.Models
{
    public class TestpaperitemModel
    {
        public int iid { get; set; }
        public string question { get; set; }
        public int paperid { get; set; }
        public float select1_score { get; set; }
        public float select2_score { get; set; }
        public float select3_score { get; set; }
        public float select4_score { get; set; }
    }
}
