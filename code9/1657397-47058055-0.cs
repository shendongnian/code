    public class Axis
    {
        public Axis(string name)
        {
            Name = name;
        }
        public string Name { get; }
        public static Axis X { get; } = new Axis("X");
        public static Axis CreateX() => new Axis("X");
    }
