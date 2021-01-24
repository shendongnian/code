        public IEnumerable<int> Reverse(int[] arr)
        {
            for (int i = arr.Length-1; i >= 0; i--)
            {
                yield return arr[i];
            }
        }
