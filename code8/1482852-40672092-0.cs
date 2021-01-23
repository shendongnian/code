        static IEnumerable<int> LuckyNumbers()
        {
            IEnumerable<int> luckyNumbers = Enumerable.Range(1, int.MaxValue);
            int counter = 0;
            while (true)
            {
                int number = luckyNumbers.ElementAt(counter++);
                yield return number;
                int moduloCheck = Math.Max(number, 2);
                luckyNumbers = luckyNumbers.Where((_, index) => (index + 1) % moduloCheck != 0);
            }
        }
