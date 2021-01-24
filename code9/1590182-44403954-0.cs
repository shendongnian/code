    public class Car
    {
        public Engine Engine
        {
            get;
            private set;
        }
        public Car(Engine engine)
        {
            this.Engine = engine;
        }
    }
    public class MercedesCar : Car
    {
        public MercedesCar() : base(new MercedesEngine())
        {
        }
    }
    public class Engine
    {
    }
    public class MercedesEngine : Engine
    {
    }
