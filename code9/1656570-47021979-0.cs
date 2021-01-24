        public class CarService : IVehicleService
        {
            private readonly Car _car;
            public CarService(Car car)
            {
                _car = car;
            }
            public void ServiceVehicle()
            {
                Console.WriteLine($"Service Car {_car.Id}");
            }
        }
