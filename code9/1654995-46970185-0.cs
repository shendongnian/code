    class Program
    {
            static void Main(string[] args)
            {
                var items = new[] {12,14,22,24,6};//new[] { 15, 85, 32, 31, 2};//new[] { 44, 55, 605, 100, 154, 190 };
                var totalItems = items.Count();
                var numberOfItemsToSelect = 3;
    
                var result = Find(totalItems, items, numberOfItemsToSelect);            
    
                PrintList(result);
    
                Console.ReadLine();
            }
    
            static void PrintList(IEnumerable<int> scoreList)
            {
                foreach (var score in scoreList)
                {
                    Console.Write(score);
                    Console.Write(" ");
                }
            }
    
            public static int[] Find(int totalItems, int[]values, int totalTobeSelected)
            {
                var result = new List<int>();
                if (totalTobeSelected <= 1)
                {
                    result.Add(values.Max());
    
                }
                else if (totalTobeSelected == totalItems)
                {
                    result.AddRange(values.OrderBy(i => i).ToList());
                }
                else
                {
                    
                    var mainSet = values.OrderBy(i => i).ToList();
                    var setDic = new Dictionary<int, IEnumerable<int>>();
    
                    for (int i = 0; (totalItems - i >= totalTobeSelected); i++)
                    {
                        var set = mainSet.GetRange(i, totalTobeSelected);
    
                        //Inside a set, we choose the difference between the first and the second number
                        // ex: set = {2, 4, 9} => diff = |2-4| = 2.
                        var diff = Math.Abs(set[0] - set[1]);
    
                        // given two sets with the same diff, we select the first one base on the sort order of the main set:
                        // ex: main set = {2,4,8,10}. Both {2,4} and {6,8} have a diff of 2 so we select {2,4}
                        if (setDic.ContainsKey(diff)) continue;
                        setDic.Add(diff, set);
    
                    }
    
                    if (setDic.Count > 0)
                    {
                        var minKey = setDic.Keys.Min();
                        result.AddRange(setDic[minKey]);
                    }
    
                }
                return result.ToArray();
            }
        }
