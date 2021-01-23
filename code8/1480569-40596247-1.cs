    public class Car
    {
    private string colour;
    private double speed;
    // Is it valid to have just a color and not a speed as well?
    public Car(string colour)
    {
        this.colour = colour;
        // Initialize it to 0.0
        speed = 0.0;
    }
    public Car(string colour, double speed)
    {
        this.colour = colour;
        this.speed = speed;
    }
    // In C# this should be a property
    public string Colour
    {
        get { return colour; }
    }
    public double Speed
    {
        get { return speed; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("red" + " " + 50d);
            Car car2 = new Car("Yellow" +" " + 60d);
            // Do something like the following to print what you want
            Console.WriteLine(car1.Colour + " " + car1.Speed);
            Console.WriteLine(car2.Colour + " " + car2.Speed);
            Console.ReadKey();
        }
    }
    }
