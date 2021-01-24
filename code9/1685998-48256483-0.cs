        static void Main(string[] args)
        {
            var ret = SendMessageToIoTHubAsync("temperature", 15);
            ret.Wait();
            Console.WriteLine("completed:" + ret.IsCompleted);
            Console.ReadLine();
        }
