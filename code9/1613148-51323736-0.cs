        private static BufferBlock<string> _buffer = new BufferBlock<string>();
        private static Task _consumer;
        private static CancellationTokenSource _cts;
        public static void Main(string[] args)
        {
            _buffer = new BufferBlock<string>();
            _cts = new CancellationTokenSource();
            _consumer = ConsumeAsync(_buffer, _cts.Token);
            for (int i = 0; i < 100000; i++)
            {
                WriteToConsole(i.ToString());
            }
            Console.ReadLine();
        }
        private static void WriteToConsole(string message)
        {
            SendToBuffer(_buffer, message);
        }
        private static void SendToBuffer(ITargetBlock<string> target, string message)
        {
            target.Post(message);
        }
        private static async Task ConsumeAsync(IReceivableSourceBlock<string> source, CancellationToken cancellationToken)
        {
            while (await source.OutputAvailableAsync(cancellationToken))
            {
                var message = await source.ReceiveAsync();
                Console.WriteLine(message);
            }
        }
