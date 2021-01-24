    class Example
    {
        public async Task Start()
        {
            await getFolderPath();
            Console.WriteLine("...");
        }
        async Task getFolderPath()
        {
            await Task.Delay(1000);
        }
    }
