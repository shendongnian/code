    public interface IColored
    {
        string Color { get; set; }
    }
    public class Paint : IColored
    {
        public string Color { get; set; }
    }
    public class Car : IColored
    {
        public string Color { get; set; }
    }
    ...
    var objects = new IColored[]
    {
        new Car { Color = "Red" },
        new Panda { Color = "Black" }
    };
    foreach (IColored value in objects)
    {
        Console.WriteLine(value.Color);
    }
