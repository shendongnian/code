    public class Engine
    {
         public Engine() { ... }     
    
         public int Code { get; set; }
    
         public DateTime Year { get; set; }
    }
    
    public class Car
    {
         public Car(Engine engine) : this() { 
              this.Engine = engine;
         }
    
         public Car() {
         } 
    
         public string Brand { get; set; }
    
         public String Model { get; set; }
    
         public Engine Engine { get; set; }
    }
