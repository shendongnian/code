    // First define the interfaces
    public interface IC1 { }
    public interface IC2 { }
    
    // Then extend the with the GetAll methods
    public static class ICExtensions
    {
      public static List<C1> GetAllC1(this IC1, string search = null) { ... } 
      public static List<C2> GetAllC2(this IC2, string search = null) { ... }
    }
    
    // These are now your controllers
    public class C1Controller : ApiController, IC1 { ... }
    public class C2Controller : ApiController, IC2 { ... }
    
    // And here is the new controller that has the two GetAll methods
    public class C1AndC2Controller : ApiController, IC1, IC2 { ... }
