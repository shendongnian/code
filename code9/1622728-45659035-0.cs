    class Program
    {
        class DataRetriever
        {
            public event Action<float> DataReady;
            private float ReadData() => 1;
            public async Task StartReading()
            {
                while (true)
                {
                    await Task.Delay(1000);
                    DataReady?.Invoke(ReadData());
                }
            }
        }
        class DataWriter
        {
            public void WriteData(float dataToWrite)
            {
                Console.WriteLine(dataToWrite);
            }
        }
        static void Main(string[] args)
        {
            var reader1 = new DataRetriever();
            var reader2 = new DataRetriever();
            var reader3 = new DataRetriever();
            var writer1 = new DataWriter();
            var writer2 = new DataWriter();
            reader1.DataReady += writer1.WriteData;
            reader2.DataReady += writer2.WriteData;
            reader3.DataReady += writer2.WriteData;
            Task.Run(reader1.StartReading);
            Task.Run(reader2.StartReading);
            Task.Run(reader3.StartReading);
            Console.ReadKey();
        }
    }
