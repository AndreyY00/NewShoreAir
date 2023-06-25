using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Journey
    {
        public int JourneysID{ get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }        
        public double Price { get; set; }
        /*Indica que JourneyFlight va a tener multiples instancias de Journey */
        public virtual ICollection<JourneyFlight> JourneyFlights { get; set; }


    }
}
