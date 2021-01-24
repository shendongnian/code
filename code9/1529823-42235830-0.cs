        public static void Main(string[] args)
        {
            Both();
        }
        static void Both() {
            var list = new Task [2];
            list[0]  = PauseAndWrite();
            list[1]  =  WriteMore();
            Task.WaitAll(list);
        }
        static async Task PauseAndWrite() {
            await Task.Delay(2000);
            Console.WriteLine("A !");
        }
        static async Task WriteMore() {
                
            for(int i = 0; i<5; i++) {
                await Task.Delay(500);
                Console.WriteLine("B - " + i);
            }
        }
