using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Flight
    {
        public int FlightID { get; set; }
        public int TransportID { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }        
        public double Price { get; set; }
        public virtual Transport Transport { get; set; }

        /*Indica que JourneyFlight va a tener multiples instancias de Flight */
        public virtual ICollection<JourneyFlight> JourneyFlights { get; set; }

    }
}
