    class Program
    {
        static void Main(string[] args)
        {
            var client = new SignalRMasterClient("http://localhost:9321/signalr");
            // Send message to server.
            client.SayHello("Message from client to Server!");
            Console.ReadKey();
            // Stop connection with the server to immediately call "OnDisconnected" event 
            // in server hub class.
            client.Stop();
        }
    }
