﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class JourneyFlight
    {
        public int JourneyID { get; set; }
        public int FlightID { get; set; }

        public virtual Journey Journey { get; set;}
        public virtual Flight Flight { get; set;}

    }
}
