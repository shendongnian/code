    class Program
    {
        static async Task Main(string[] args)
        {
            GetProjectClass t = new GetProjectClass();
            await t.GetProjects();
            Console.WriteLine("finished");
            Console.ReadKey();
        }
    }
