    public class Dictionary
    {
        public Dictionary<string, double> Length {get;}
        public void References()
        {
            Length = new Dictionary<string, double>(Lengths);
    
            Length.Add("Feet", 1);
            Length.Add("Meters", 0.3048);
        }
    }
