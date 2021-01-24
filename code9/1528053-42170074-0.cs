       using System.Linq; // Need;
       internal class Program
       {
         private static void Main()
         {
           IEnumerable<TOld> told = new List<TOld> { new TOld { Name = "Name1", Age = 18 } };
           IEnumerable<TNew> tnew = told.ToList().ConvertAll(t => new TNew { Name = t.Name, Age = t.Age });
      
           foreach (var @new in tnew)
             Console.WriteLine(@new.Name);
         }
       }
      
       public class TOld
       {
         public string Name { get; set; }
         public int Age { get; set; }
       }
      
       public class TNew
       {
         public string Name { get; set; }
         public int Age { get; set; }
       }
