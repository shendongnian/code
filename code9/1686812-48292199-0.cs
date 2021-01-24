    public static class ArrayExtensions
    {
        private static IEnumerable<int[]> CreatePermutations(int[] lengths, int pos = 0)
        {
            for (var i = 0; i < lengths[pos]; i++)
            {
                var newArray = (int[])lengths.Clone();
                newArray[pos] = i;
                if (pos + 1 >= lengths.Length)
                {
                    yield return newArray;
                    continue;
                }
                foreach (var next in CreatePermutations(newArray, pos + 1)) yield return next;
            }
        }
        public static Array Select<T,P>(this Array target, Func<T, P> func)
        {
            var dimensions = target.Rank;
            var lengths = Enumerable.Range(0, dimensions).Select(d => target.GetLength(d)).ToArray();
            var array = Array.CreateInstance(typeof(P), lengths);
            var permutations = CreatePermutations(lengths);
            foreach (var index in permutations)
            {
                array.SetValue(func((T)target.GetValue(index)), index);
            }
            return array;
        }
    }
