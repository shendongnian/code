    public class Program {
        public static void Main(string[] args) {
            var list = new List<MyClient>();
            for (var i = 0; i < 10000; i++) {
                Console.WriteLine($"Creating {i} instance");
                list.Add(new MyClient(new Channel("127.0.0.1:61783", ChannelCredentials.Insecure)));
            }
            Console.WriteLine("press enter to dispose clients");
            Console.ReadLine();
            list.ForEach(c => c.Dispose());
            Console.WriteLine("press enter to list = null");
            Console.ReadLine();
            list = null;
            Console.WriteLine("press enter to GC.Collect();");
            Console.ReadLine();
            GC.Collect();
            Console.WriteLine("press enter to exit");
            Console.ReadLine();
        }
    }
