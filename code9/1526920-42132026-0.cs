        public class TrainspotterItenaryViewModel
        {
            private Dictionary<int, Leg> _legNumberToLegIndex { get; set; }
            public IEnumerable<Leg> Legs => _legNumberToLegIndex?.Values
            public void AddToLeg(int legNumber, Station station)
            {
                if (_legNumberToLegIndex == null)
                {
                    _legNumberToLegIndex = new Dictionary<int, Leg>();
                }
                Leg leg;
                if (!_legNumberToLegIndex.TryGetValue(legNumber, out leg))
                {
                    leg = new Leg
                    {
                        LegNumber = legNumber,
                        Stations = new List<Station>()
                    };
                    _legNumberToLegIndex.Add(legNumber, leg);
                }
                leg.Stations.Add(station);
            }
        }
