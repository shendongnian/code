            var rolls = new List<int>();
            var rollrnd = new Random();
            var range = Enumerable.Range(1, 4);
            for (var i = 0; i < 6; i++) {
                rolls.Add(rollrnd.Next(1, 6));
            }
            rolls.ForEach(x=> Console.WriteLine(x)); // These lines are equivalent
            rolls.ForEach(Console.WriteLine);        // Just showing another way of doing it.
        }
