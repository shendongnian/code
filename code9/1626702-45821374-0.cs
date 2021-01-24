    public class Person
    {
      public string Name { get; set; }
      public int Age { get; set; }
    }
    
    public class A
    {
      public Person B { get; set; }
      public Person C { get; set; }
      public Person D { get; set; }
      public Person E { get; set; }
    }
    
    internal static class Program
    {
      private static void Method(A a)
      {
        Console.WriteLine(a.E.Name);
      }
    
      internal static void Main()
      {
        var a = new A 
                 {
                    B = new Person { Name = "Peter", Age = 31 }, 
                    C = new Person { Name = "Paul", Age = 78 }, 
                    D = new Person { Name = "Mary", Age = 24 }, 
                    E = new Person { Name = "Jane", Age = 15 } 
                 };
    
        Method(a);
      }
    }
