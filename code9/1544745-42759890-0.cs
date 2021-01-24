    public class AircraftViewModel
    {
        public string AirportName {get; set; }
    
        public string AirportAircraftType {get; set;}
    
        public int AircraftSeatsSum {get; set; }
    }
    
    [..]
    
    var outputStats = temp.AircraftList.GroupBy(p => p.aircraftType);
    List<AircraftViewModel> vm = new List<AircraftViewModel>();
    
         foreach (var item in outputStats)
         {
             var aircraft = new AircraftViewModel();
             aircraft.AirportName = temp.name;
             aircraft.AirportAircraftType = item.Key;
             aircraft.AircraftSeatsSum = item.Sum(p => p.seats);
             vm.Add(aircraft);
         }
     }
    
     ViewBag.Output = vm;
