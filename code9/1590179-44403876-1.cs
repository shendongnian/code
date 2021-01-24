    //still the same
    public class Engine
    {
         public Engine() { ... }     
    
         public int Code { get; set; }
    
         public DateTime Year { get; set; }
    }
    
    public class Car
    {
         public Car() {
            //_engine = new Engine();
         }
         //Engine initialisation can be either here or inside the constructor (check constructor's commented code)
         private readonly Engine _engine = new Engine();
    
         public string Brand { get; set; }
    
         public String Model { get; set; }
    
         //you shouldn't be able to assign an _engine from outside
         public Engine Engine { get { return _engine; } }
    }
