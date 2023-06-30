using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class NewShoreAirContext: DbContext
    {
        public NewShoreAirContext(DbContextOptions<NewShoreAirContext> option) : base(option)
        {

        }
        public DbSet<Transport> Transportes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Journey> Journeys { get; set; } 
        public DbSet<JourneyFlight> JourneyFlights { get; set; }

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            List<Transport> transportsInit = new List<Transport>();
            List<Flight> FlightInit = new List<Flight>();
            string response = await InitialDataController.RequestApi();
            InitialDataController.SaveData(response,ref transportsInit,ref FlightInit); */
            modelBuilder.Entity<Transport>(transport =>
            {
                transport.ToTable("transport");
                transport.HasKey(p => p.TransportID);
                transport.Property(p=> p.FlightCarrier).IsRequired().HasMaxLength(5);
                transport.Property(p=> p.FlightNumber).IsRequired().HasMaxLength(10); 
              //  transport.HasData(transportsInit);
            });

            modelBuilder.Entity<Flight>(flight =>
            {
                flight.ToTable("flight");
                flight.HasKey(p => p.FlightID);
                flight.HasOne(p => p.Transport).WithMany(cp => cp.Flights).HasForeignKey(p => p.TransportID);
                flight.Property(p => p.Origin).IsRequired();
                flight.Property(p => p.Destination).IsRequired();
                flight.Property(p => p.Price).IsRequired();
            //    flight.HasData(FlightInit);
            });

            modelBuilder.Entity<Journey>(journey =>
            {
                journey.HasKey(p => p.JourneysID);
                journey.Property(p => p.Origin).IsRequired().HasMaxLength(10);
                journey.Property(p => p.Destination).IsRequired().HasMaxLength(10);
                journey.Property(p => p.Price).IsRequired();
                
            });
            modelBuilder.Entity<JourneyFlight>(journeyflight =>
            {
                journeyflight.HasKey(p => new {p.JourneyID,p.FlightID} );
                journeyflight.HasOne(p => p.Journey).WithMany(cp => cp.JourneyFlights).HasForeignKey(p => p.JourneyID);
                journeyflight.HasOne(p => p.Flight).WithMany(cp => cp.JourneyFlights).HasForeignKey(p => p.FlightID);

            });


        }

    }
}