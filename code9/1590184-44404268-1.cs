    public class Car
    {
        public Car(IEngine engine)
        {
            Engine = engine;
        }
        public IEngine Engine { get; set; }
    }
    var car = new Car(new Engine());
