    public int NumdiffLinear(int[] arr, int K)
            {
                var dupsDictionary =
                    arr
                        .GroupBy(i => i)
                        .ToDictionary(g => g.Key, g => g.Count());
    
    
                return dupsDictionary.Keys.Aggregate(
                    0,
                    (total, i) =>
                        total +
                        dupsDictionary.Keys.Where(key => i - key == K)
                            .Sum(key => dupsDictionary[key]*dupsDictionary[i]));
            }
