        static void Main(string[] args)
        {
            var randomList = new List<int>();
            var random = new Random(1969);
            for (var i = 0; i < 10; i++)
            {
                randomList.Add(random.Next(0, 500));
            }
            foreach (var item in randomList)
            {
                Console.WriteLine("Random Number: " + item);
            }
            var AveNum = new List<double>();
            int range = 3; //Change this for different range
            for (int i = 1; i < 10-range; i++)
            {
                var three = randomList.GetRange(i, range);
                double result = three.Average();
                Console.WriteLine("Average Number: " + result);
                AveNum.Add(result);
            }
            Console.WriteLine("Largest: " + AveNum.Max());
        }
