    interface IThing {}
    class Foo : IThing {}
    delegate T ThingCreator<T>() where T : IThing;
    public class Program
    {
      static  void Test<T>(ThingCreator<T> tc) where T : IThing
      {
        Console.WriteLine(tc.Method.ReturnType);
      }
      public static void Main()
      {
        Test(() => new Foo());		
      }
    }
