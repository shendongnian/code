     public class FuelConsumer
     {
         private readonly IFuel fuel;
     
         public FuelConsumer(IFuel fuelData)
         {
             fuel = fuelData;
         }
     
         public string GetFuelDetails()
         {
             return $"This pump dispenses {fuel.Name} and the price is {fuel.Price} per litre.";
         }
     }
