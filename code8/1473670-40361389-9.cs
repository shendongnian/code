    public class Apple
    {
        public Apple() { }
        public Apple(Apple apple)
        {
            Color = apple?.Color;
        }
        public string Color { get; set; }
    }
    var redAppels = apples.Where(a => a.Color == "red")
                          .Select(a => new Apple(a))
                          .ToList();
