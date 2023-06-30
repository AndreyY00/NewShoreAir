using DB;
using DB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShoreAir.Controllers
{
    internal class InitialDataController
    {

        public static async Task<string> RequestApi()
        {
            using (HttpClient client = new HttpClient())
            {
                // Establecer la URL base de la API
                client.BaseAddress = new Uri("https://recruiting-api.newshore.es");

                // Realizar una solicitud GET a un endpoint específico
                HttpResponseMessage response = await client.GetAsync("/api/flights/2");

                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta como una cadena de texto
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
                else
                {
                    // Manejar el error
                    return("Error en la solicitud: " + response.StatusCode);
                }
            }
        }
        public async static Task SaveData(string response, NewShoreAirContext context)
        {
            try
            {
                int Count = context.Transportes.Count();
                if (Count == 0)
                {

                    var lista = JsonConvert.DeserializeObject<List<dynamic>>(response);
                    int transportIncrement = 0, flightIncrement = 0;
                    List<Transport> ListDataTransport = new ();
                    List<Flight> ListDataFlights = new ();
                    /*GUARDAR LA INFORMACION EN LA BAE DE DATOS DE LOS TRASNPORTES*/
                    foreach (var x in lista)
                    {
                        Transport DataTransport = new ();
                        DataTransport.FlightCarrier = x.flightCarrier;
                        DataTransport.FlightNumber = x.flightNumber;
                        ListDataTransport.Add(DataTransport);
                    }
                    await context.Transportes.AddRangeAsync(ListDataTransport);
                    await context.SaveChangesAsync();
                    /*GUARDAR LA INFORMACION EN LA BAE DE DATOS DE LOS TRASNPORTES*/
                    foreach (var x in lista)
                    {
                        Flight DataFlights = new();
                        DataFlights.Origin = x.departureStation;
                        DataFlights.Destination = x.arrivalStation;
                        DataFlights.Price = x.price;
                        string flightCarrierVal = x.flightCarrier;
                        string flightNumberVal = x.flightNumber;
                        DataFlights.TransportID = context.Transportes.Where(p => p.FlightCarrier == flightCarrierVal && p.FlightNumber == flightNumberVal).Select(p=> p.TransportID).FirstOrDefault();
                        if (DataFlights?.TransportID>0) 
                        {
                            ListDataFlights.Add(DataFlights);
                        }
                    }
                    await context.Flights.AddRangeAsync(ListDataFlights);
                    await context.SaveChangesAsync();


                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
