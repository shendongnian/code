            var bag = new ConcurrentBag<KeyValuePair<int, int>>();
            Parallel.For(1, 101, (i) => { bag.Add(new KeyValuePair<int, int>(i, i * i)); });
            var results = bag.ToDictionary(pair => pair.Key, pair => pair.Value);
            Console.WriteLine("Square of 56 is " + results[56].ToString());
            Console.WriteLine("Sum of all squares is " + results.Sum(pair => pair.Value).ToString());
