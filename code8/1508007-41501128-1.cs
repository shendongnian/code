    class Program
    {   
      static void Main(string[] args)
      {
          tmpClass testClass = new tmpClass();
          Debug.WriteLine(testClass.IntTest);
      }
      public class tmpClass
      {
          public int IntTest { get; set; }
      }
    }
