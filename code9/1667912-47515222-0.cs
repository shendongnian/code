          class Program
          {
            static void Main(string[] args)
            {
              var allCars = GetAllCars();
              var allCarsDtoDict = allCars.Select(a =>
              new CarDTO() { Id_Base = a.Id_Base, IdCar = a.IdCar, Name = a.Name }).ToDictionary(a => a.IdCar, a => a);
              foreach (var car in allCarsDtoDict.Values)
              {
                if (car.Id_Base.HasValue)
                  car.InnerCar = allCarsDtoDict[car.Id_Base.Value];
              }
          
              var allCardWithSetInnerCard = allCarsDtoDict.Values;
            }
          
            private static IEnumerable<CarDO> GetAllCars()
            {
              return new List<CarDO>()
              {
                new CarDO(){ IdCar = 1, Name = "Toyota", Id_Base = null},
                new CarDO(){ IdCar = 2,Name = "Honda",Id_Base = 5,},
                new CarDO(){ IdCar = 3,Name = "Ford",Id_Base = 4},
                new CarDO(){ IdCar = 4, Name = "Buick", Id_Base = null },
                new CarDO(){IdCar = 5,Name = "Volvo",Id_Base = 1,}
              };
            }
          }
