              List<int[]> arraysList = new List<int[]>();
            arraysList.Add(new int[] { 2, 3, 5 });
            arraysList.Add(new int[] { 2, 3, 5, 9, 123, 5 });
            arraysList.Add(new int[] { 3 });
            arraysList.Add(new int[] { 9,8 });
            ConcurrentBag<int> SummedValueOfEveryArray = new ConcurrentBag<int>();
            Parallel.ForEach(arraysList, array =>
            {
                SummedValueOfEveryArray.Add(array.Sum());
            });
            //Your result
            var result = SummedValueOfEveryArray.ToArray<int>();
            //The sum of all arrays
            var totalSum = SummedValueOfEveryArray.Sum();
