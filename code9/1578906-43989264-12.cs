    public class Auto
    {
        public Frame Frame { get; set; }
        public Motor Motor { get; set; }
        public Auto(string make, string model, string color, int volume, double power)
        {
            Frame = new Frame(make, model, color);
            Motor = new Motor(volume, power);
        }
        public void DisplayDetails()
        {
            Console.WriteLine("Make:" + Frame.Make);
            Console.WriteLine("Model:" + Frame.Model);
            Console.WriteLine("Color:" + Frame.Color);
            Console.WriteLine("Volume:" + Motor.Volume);
            Console.WriteLine("Power (kW):" + Motor.Power);
            Console.WriteLine("Horsepower:" + Motor.Horsepower);
        }
        public void ShowComparison(Auto other)
        {
            ShowComparison(this, other);
        }
        public static void ShowComparison(Auto first, Auto second)
        {
            var firstIsGreater = (first == null)
                ? second == null
                : first.Motor == null
                    ? second.Motor == null
                    : first.Motor.Power > second.Motor.Power;
            Console.WriteLine((firstIsGreater)
                ? $"The motor of {first} is more powerful than {second}"
                : $"The motor of {second} is more powerful than {first}");
        }
        public override string ToString()
        {
            return $"{Frame.Make} {Frame.Model}";
        }
    }
