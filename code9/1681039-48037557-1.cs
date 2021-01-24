    public class Serial
    {
        SerialPort s;
        public Serial()
        {
            InitSerialPort();
            // Ignore returned task...constructors shouldn't wait. You could store
            // the task in a class field, to provide a mechanism to observe the
            // receiving state.
            Task task = ReceiveLoopAsync();
        }
        private async Task ReceiveLoopAsync()
        {
            using (StreamWriter writer = new StreamWriter(s.BaseStream))
            using (StreamReader reader = new StreamReader(s.BaseStream))
            {
                string line;
                while ((line = reader.ReadLineAsync()) != null)
                {
                    if (line == "hello")
                    {
                        // Ignore returned task...we don't really care when it finishes
                        Task task = RespondAsync(writer);
                    }
                }
            }
        }
        private async Task RespondAsync(StreamWriter writer)
        {
            await Task.Delay(500);
            writer.WriteLine("hello to you friend");
        }
    }
