    static class SequencesCalculation
    {
        public static List<int[]> Calculate(int[] availableValues, int digitsCount)
        {
            var combIndexes = CalculateRecursive(new List<int[]>(), availableValues.Length, new int[digitsCount], digitsCount - 1);
            var result = combIndexes.Select(x => x.Select(i => availableValues[i]).ToArray()).ToList();
            return result;
        }
        static List<int[]> CalculateRecursive(List<int[]> doneCombinations, int valuesCount, int[] array, int i)
        {
            doneCombinations.Add((int[])array.Clone());
            //base case
            if (array.All(x => x == valuesCount - 1))
                return doneCombinations;
            NextCombination(array, valuesCount, i);
            return CalculateRecursive(doneCombinations, valuesCount, array, i);
        }
        static void NextCombination(int[] array, int valuesCount, int i)
        {
            array[i] = (array[i] + 1) % valuesCount;
            if (i == 0)
                return;
            if (array[i] == 0)
                NextCombination(array, valuesCount, i - 1);
        }
    }
