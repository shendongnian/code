    var arr = new int[] { 1, 5, 2, 3, 5 };
            int max = arr.Max();
            List<int> indexes = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == max)
                    indexes.Add(i);
            }
    int highindex = indexes.LastOrDefault();
