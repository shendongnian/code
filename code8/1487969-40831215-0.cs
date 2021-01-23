            int input = 0;
            var inputs = new List<int>();
            while (input != -1)
            {
                input = int.Parse(Console.ReadLine());
                int count = 0;
                count++;
                inputs.Add(input);
            }
            var result = inputs.Select((j, i) => Tuple.Create("The " + i, j)).ToList();
