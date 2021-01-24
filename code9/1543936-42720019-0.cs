            var list = new List<string> { "A", "B", "E", "A", "E", "A", "B", "E", "C", "B", "A", "D", "B", "E" };
            var sortOrder = new List<string> { "F", "E", "C", "A", "B", "D" };
            var resultSets = new List<List<string>> ();
            for (int i = 0; i < sortOrder.Count(); i++)
            {
                var currentLetter = sortOrder[i];
                for (int j = 0; j < list.Count(x=> x == currentLetter); j++)
                {
                    if(resultSets.Count() < j + 1)
                    {
                        resultSets.Add(new List<string>());
                    }
                    resultSets[j].Add(currentLetter);
                }
            }
            var result = string.Join(", ", resultSets.SelectMany(x => x));
            Console.WriteLine($"Results: { result}");
