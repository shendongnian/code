     namespace stacketst
             {
                
      public class CarsBase
            {
      public string DisplayName { get; set; }
      public CarsBase()
      {
             //called when CarBase object is initialized
             DisplayName = "Base Car";
                
            }
            }
    public class Toyota : CarsBase
     {
    //getters , setters called as properties in C#         
     public int number_of_wheels { get; set; }
    public double fuel_capacity { get; set; }
     public string engine_type { get; set; }
                
    public Toyota() //called when an instance of Toyota is created
    {
    //assinging value to this property calls set 
    fuel_capacity = 4.2; 
     number_of_wheels = 4; 
    engine_type = EngineType.name_engines.UZ.ToString(); 
    }     
    }
                
    public class TestClass
    {
                        
    static void Main()
    {
    //when below line is executed,constructor is fired & the initialization of variable inside constructor takes place    
    var myVar = new Toyota();
    }
    }
    }
        
        
    namespace stacketst
    {
    public class EngineType
    {
    //enums to hold constants, common for any Car Class
     public enum name_engines 
    { 
      
     V12, V10, V8, V6, UZ        
    };
     }
    }
