    class Client
    {
        static async Task Main(string[] args)
        {
            using (NamedPipeClientStream pipe = new NamedPipeClientStream(".", "testpipe", PipeDirection.InOut))
            {
                pipe.Connect(5000);
                pipe.ReadMode = PipeTransmissionMode.Message;
                byte[] ba = Encoding.Default.GetBytes("hello world");
                pipe.Write(ba, 0, ba.Length);
                var result = await Task.Run(() => {
                    return ReadMessage(pipe);
                });
                Console.WriteLine("Response received from server: " + Encoding.UTF8.GetString(result));
                Console.ReadLine();
            }
        }
        private static byte[] ReadMessage(PipeStream pipe)
        {
            byte[] buffer = new byte[1024];
            using (var ms = new MemoryStream())
            {
                do
                {
                    var readBytes = pipe.Read(buffer, 0, buffer.Length);
                    ms.Write(buffer, 0, readBytes);
                }
                while (!pipe.IsMessageComplete);
                return ms.ToArray();
            }
        }
    }
