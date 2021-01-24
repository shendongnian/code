    static void Main(string[] args) {
        using (var host = new NancyHost(new Uri("http://localhost:34455"))) {
            host.Start();
            Console.WriteLine("started");
            Console.ReadKey();
        }
    }
    public class SampleModule : Nancy.NancyModule {
        public SampleModule() {
            Get["/"] = _ => "Hello World!";
        }
    }
