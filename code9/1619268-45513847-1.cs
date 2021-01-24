    public struct Position
    {            
        public double X { get; set; } 
        public double Y { get; set; }
    }
    public class Car
    {
        public bool IsEnabled { get; set; }
        public Position Position { get; private set; }
        public bool IsInMotion { get; set; }
        public void MoveCar(Position position)
        {
            if (IsEnabled && !IsInMotion)
	        {
		        Position = position;
	        }
        }
    }
    class CarSimulator
    {
        List<Car> cars = new List<Car>(); // populate it
        void MoveAllCars()
        {
            foreach (var car in cars)
            {
                car.MoveCar(GetPosition());
            }
        }
    }
