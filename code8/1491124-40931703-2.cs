        public static void Main(string[] args)
        {
            try
            {
                Task t = TestError();
                t.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Catched");
            }
            Console.ReadLine();
        }
        public static async Task TestError()
        {
                // Task.Run(() => GetMoreCodes(CodeBufferMaxSize));
                // await Task.Run(() => GetMoreCodes(0));
                await Task.Run(() => { throw new Exception("test!"); });
        }
