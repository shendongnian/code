    public class Artist
    {
        public string Name { get; set; }
        public List<string> Cars { get; set; }
        public int ID { get; set; }
        public List<Artist> Profile()
        {
            var artistList = new List<Artist>();
            // Artist: 1
            artistList.Add(new Artist()
            {
                ID = 1,
                Name = "Nick Cage",
                Car = new List<string>
                {
                    "Corvette",
                    "Porsche 718",
                    "Audi"
                }
            });
            // Artist 2
            artistList.Add(new Artist()
            {
                ID = 2,
                Name = "Ryan Rynolds",
                Car = new List<string>
                {
                    "Lotus",
                    "Alfa Romeo",
                    "Jaguar"
                }
            });
            return artistList;
        }
    }
