    public class Paint
    {
        public string Color { get; set; }
    }
    public class Car
    {
        public string Color { get; set; }
    }
    ...
    var objects = new object[]
    {
        new Car { Color = "Red" },
        new Panda { Color = "Black" }
    };
    foreach (dynamic value in objects)
    {
        Console.WriteLine(value.Color);
    }
