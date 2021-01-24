    class NumbersForTotalFinder
    {
        public NumbersForTotalFinder(IEnumerable<int> numbers)
        {
            _numbers = numbers.OrderBy(n => n).ToArray();
        }
        public List<int[]> Find(int total)
        {
            var results = new List<int[]>();
            var temp = new int[_numbers.Length];
            for (var index = 0; index < _numbers.Length; index++)
            {
                var num = _numbers[index];
                temp[0] = num;
                if (num == total)
                {
                    SaveResult(results, temp, 1);
                }
                if (num >= total)
                {
                    break;
                }
                Check(index + 1, 1, num, total, results, temp);
            }
            return results;
        }
        private void Check(int index, int depth, int sum, int total, List<int[]> results, int[] temp)
        {
            while (index < _numbers.Length)
            {
                int newNum = _numbers[index];
                int newSum = sum + newNum;
                if (newSum > total)
                {
                    break;
                }
                temp[depth] = newNum;
                if (newSum == total)
                {
                    SaveResult(results, temp, depth + 1);
                    break;
                }
                Check(index + 1, depth + 1, newSum, total, results, temp);
                index++;
            }
        }
        private void SaveResult(List<int[]> results, int[] temp, int length)
        {
            var newResult = new int[length];
            Array.Copy(temp, newResult, length);
            results.Add(newResult);
        }
        private int[] _numbers;
    }
  
