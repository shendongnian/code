        public static int[] Find(int totalItems, int[] values, int totalToBeSelected)
        {
            int[] results = new int[totalToBeSelected];
            Array.Sort(values);
            Array.Reverse(values);
            int diff = values.Max() - values.Min();
            for (int i = 0; i < values.Length - totalToBeSelected +1; i++)
            {
                int temp_diff = values[i] - values[i + totalToBeSelected - 1];
                if (temp_diff < diff )
                {
                    diff = temp_diff;
                    for (int j = 0; j < totalToBeSelected; j++)
                    {
                        results[j] = values[i + j];
                    }
                }
            }
            return results;
        }
