    // Don't forget to include the access modifier
    class Car
    {
    private string colour;
    private double speed;
    // Is it valid to have just a color and not a speed as well?
    public Car(string colour)
    {
        this.colour = colour;
    }
    public Car(string colour, double speed)
    {
        this.colour = colour;
        this.speed = speed;
    }
    // In C# this should be a property
    public string GetColour()
    {
        return colour;
    }
    public double GetSpeed()
    {
        return speed;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("red" + " " + 50d);
            Car car2 = new Car("Yellow" +" " + 60d);
            This is incorrect
            Console.WriteLine(car1);
            Console.WriteLine(car2);
            Console.ReadKey();
        }
    }
    }
