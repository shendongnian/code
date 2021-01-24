        public List<Leg> Legs { get; set; } = new List<Leg>();
        public void AddToLeg(int legNumber, Station station)
        {
            var leg = Legs.FirstOrDefault(x => x.LegNumber == legNumber);
            if (leg == null)
            {
                leg = new Leg
                {
                    LegNumber = legNumber,
                    Stations = new List<Station> { station }
                };
                Legs.Add(leg);
                Console.WriteLine($"Leg {leg.LegNumber} Not Found- Added new leg and {station.Name}");
            }
            else
            {
                leg.Stations.Add(station);
                Console.WriteLine($"Leg {legNumber} Found- adding {station.Name}");
            }
        }
