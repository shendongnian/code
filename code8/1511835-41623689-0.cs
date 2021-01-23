           var cardLines = cards.Select(x =>
            x.ToString().Split('\r').ToList().Select(y => y.Replace("\r", string.Empty).Replace("\n", string.Empty)
            ).ToList()).ToList();
            var maximumCardHeight = cardLines.Max(x => x.Count);
            for (var i = 0; i < maximumCardHeight - 1; i++)
            {
                cardLines.ForEach(x =>
                {
                    if (i < x.Count)
                        Console.Write(x[i]);
                });
                Console.WriteLine();
            }
