    class Example
    {
        public void Start()
        {
            getFolderPath()
               .ContinueWith(t =>
               {                   
                   Console.WriteLine("...");
               });
        }
        async Task getFolderPath()
        {
            await Task.Delay(1000);
        }
    }
