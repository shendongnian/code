    public class CarIndex : AbstractIndexCreationTask<Car, CarView>
    {
        public CarIndex()
        {
            Map = cars => from car in cars
                          select new
                          {
                              car.Id,
                              car.Name,
                              car.PersonId,
                          };
        }
    }
