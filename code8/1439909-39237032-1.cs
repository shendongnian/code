    public class Car : ICar
    {
    }
    
    public class Garage : IHasCar<Car>
    {
         public Car Car { get; set; }
    
         public void DestroyCar()
         {
             // Now here your Garage implements IHasCar<Car>,
             // so Car property is typed as Car instead of IHasCar<Car>
             // and you'll be able to access Car members too!
         }
    }
