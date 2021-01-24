        public static void Main(string[] args)
        {
            var listA = new [] { 1, 1, 1, 3, 3, 5 };
            var listB = new [] { 1, 1, 3 };
            var listC = listA.SetExcept(listB).ToList();
            Console.WriteLine("listA: {0}", string.Join(",", listA.Select(e => e.ToString())));
            Console.WriteLine("listB: {0}", string.Join(",", listB.Select(e => e.ToString())));
            Console.WriteLine("listC: {0}", string.Join(",", listC.Select(e => e.ToString())));            
        }
