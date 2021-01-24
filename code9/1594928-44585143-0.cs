        public class Station : BusinessClass<Station, StationAgent>
        {
            public string StationCode { get; internal set; }
            public Location Location { get; internal set; }
            public Station(string stationCode)
            {
                base.Load(stationCode, this);
            }
        }
