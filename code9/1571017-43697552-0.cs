    namespace RPG {
    
      public class Actor {
      
      public void d(){
      System.Console.Write("fhdf");
      }
      
      }
    
      public class Character : Actor {}
    }
    
    
    ////////////////
    public class Character :  RPG.Character {}
    class Program
    {
        static void Main()
        {
            Character c = new Character();
            c.d();
            Console.WriteLine("Hello, World!");
        }
    }
