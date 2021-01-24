        private static void Main(string[] args)
        {
            var tasks = new List<Task<List<int>>>(){
                myAsyncWork1(),
                myAsyncWork2(),
                myAsyncWork3()
            };            
            var results = Task.WhenAll(tasks).Result;
            var numbers = results.SelectMany(x => x).ToList();
            Console.WriteLine(string.Join(" ", numbers.Select(x => x.ToString())));            
            Console.ReadKey();
        }
        static Task<List<int>> myAsyncWork1()
        {            
            return Task.Factory.StartNew(() =>
            {
                Console.WriteLine("MyAsyncWork1 started!");
                Thread.Sleep(300);
                Console.WriteLine("MyAsyncWork1 finished!");
                return new List<int>() { 1, 2, 3 };
            });
        }
        static Task<List<int>> myAsyncWork2()
        {
            return Task.Factory.StartNew(() =>
            {
                Console.WriteLine("MyAsyncWork2 started!");
                Thread.Sleep(200);
                Console.WriteLine("MyAsyncWork2 finished!");
                return new List<int>() { 4, 5, 6 };
            }); ;
        }
        static Task<List<int>> myAsyncWork3()
        {
            return Task.Factory.StartNew(() =>
            {
                Console.WriteLine("MyAsyncWork3 started!");
                Thread.Sleep(200);
                Console.WriteLine("MyAsyncWork3 finished!");
                return new List<int>() { 7, 8, 9 };
            });
        }
