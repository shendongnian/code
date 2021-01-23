    public class Person
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public override string ToString()
        {
            return Name + " " + Weight + " " + Height;
        }
    }
