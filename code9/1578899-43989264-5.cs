    public class Motor
    {
        public int Volume { get; set; }
        public double Power { get; set; }
        public double Horsepower { get { return Power * 1.36; } }
        public Motor(int volume, double power)
        {
            Volume = volume;
            Power = power;
        }
    }
