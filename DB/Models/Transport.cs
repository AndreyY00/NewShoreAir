using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Transport
    {
        public int TransportID { get; set; }
        public string FlightCarrier { get; set; }
        public string FlightNumber { get; set; }
        /*Indica que los vuelos tienen multiples instancias de Transport*/
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
