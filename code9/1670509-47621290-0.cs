    namespace StackOverflow
    {
       class Program
       {
          static void Main(string[] args)
          {
             List<Test> tests = new List<Test>()
             {
                new StackOverflow.Test()
                {
                    id = "test",
                    name = "name"
                },
                new StackOverflow.Test()
                {
                    id = "test1",
                    name = "name1"
                },
                new StackOverflow.Test()
                {
                    id = "test2",
                    name = "name2"
                },
            };
            var lastItem = tests.Last();
            foreach(Test test in tests)
            {
                if (test.Equals(lastItem))
                {
                    Console.WriteLine("last item has been cycled to");
                }
            }
            Console.ReadLine();            
          }
       }
       public class Test
       { 
         public string id { get; set; }
         public string name { get; set; }
       }
    }
