       var data = from f in flights
                       join p in passengers on f.ID equals p.Flight
                       where f.ID == searchId
                       select new { flight = f, passenger = p };
            if (data.Any())
            {
                var format = "{0} departs {1} for {2} on flight {3} in seat {4} on {5}";
                foreach (var item in data)
                {
                    Console.WriteLine(string.Format(format, item.passenger.Name, item.flight.Origin, item.flight.Destination,item.flight.ID, item.passenger.Seat, item.flight.Date));
                }
            }
