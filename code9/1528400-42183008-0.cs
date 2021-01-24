    public class Car
    {
        private string make { get; set; }
        private List<string> colours { get; set;}
        private List<string> trims { get; set; }
    
        public Car()
        {
            colours = new List<string>();
            trims = new List<string>();
        }
    }
