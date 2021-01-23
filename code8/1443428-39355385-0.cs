    class Program
    {
        static void Main(string[] args)
        {
            DoStuff();
            Console.ReadLine();
        }
        public static async void DoStuff()
        {
            var filename = @"C:\Example.txt";
            var sw = new Stopwatch();
            sw.Start();
            ReadAllFile(filename);
            sw.Stop();
            Console.WriteLine("Sync: " + sw.Elapsed);
            sw.Restart();
            await ReadAllFileAsync(filename);
            sw.Stop();
            Console.WriteLine("Async: " + sw.Elapsed);
        }
        static void ReadAllFile(string filename)
        {
            byte[] buffer = new byte[131072];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read, buffer.Length, false))
                while (true)
                    if (file.Read(buffer, 0, buffer.Length) <= 0)
                        break;
        }
        static async Task ReadAllFileAsync(string filename)
        {
            byte[] buffer = new byte[131072];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read, buffer.Length, true))
                while (true)
                    if ((await file.ReadAsync(buffer, 0, buffer.Length)) <= 0)
                        break;
        }
    }
