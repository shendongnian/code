    class Program
      {
          static void Main(string[] args)
          {            
              try 
              {
                  Console.WriteLine("csharp" + " " + 1/0);
              }
              catch
              {
                  throw;
              }
              finally
              {
                  Console.WriteLine("Java");            
              }
              Console.ReadLine();
          }
      }
