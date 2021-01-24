        public class CarsModel : PageModel
        {
            public List<Car> Cars { get; private set; } = new List<Car> {
                new Car{ ID = 1, Name = "Car1", Model = "M1", Description = "Some description" },
                new Car{ ID = 2, Name = "Car2", Model = "M2", Description = "Some description" },
                new Car{ ID = 3, Name = "Car3", Model = "M3", Description = "Some description" },
                new Car{ ID = 4, Name = "Car4", Model = "M4", Description = "Some description" }
            };
        }
