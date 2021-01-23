    public class Car
    {
        public int Wheels { get; set; }
    
        public string Colour { get; set; }
    }
    public interface ICarBuilder
    {
        void SetColour(string colour);
        void SetWheels(int count);
   
        Car GetResult();
    }
    public class CarBuilder : ICarBuilder
    {
        private Car car;
    
        public CarBuilder()
        {
            this.car = new Car();
        }
    
        public void SetColour(string colour)
        {
            this.car.Colour = colour;
        }
    
        public void SetWheels(int count)
        {
            this.car.Wheels = count;
        }
    
        public Car GetResult() => car;
    }
    public class CarBuildDirector
    {
        public Car ConstructRedCar()
        {
            CarBuilder builder = new CarBuilder();
    
            builder.SetColour("Red");
            builder.SetWheels(4);
    
            return builder.GetResult();
        }
        public Car ConstructGreenCar()
        {
            CarBuilder builder = new CarBuilder();
    
            builder.SetColour("Green");
            builder.SetWheels(4);
    
            return builder.GetResult();
        }
    }
