    namespace WorkflowDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                var app = new WorkflowApplication(new Activity1());
                app.Run();
                app.Completed = (s) => 
                    {
                        Console.WriteLine(s.Outputs["argument1"]);
                    };
                Console.ReadKey();
            }
        }
    } 
