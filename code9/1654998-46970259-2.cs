        public static int[] Find(int totalItems, int[] values, int totalToBeSelected)
        {
            Array.Sort(values);
            Array.Reverse(values); // We need any value greater than max items diff. Max array item (first item after the sort) enough for it.
            int diff = values[0]; 
            int indx = 0;
            for (int i = 0; i < totalItems - totalToBeSelected +1; i++)
            {
                int temp_diff = values[i] - values[i + totalToBeSelected - 1]; // We are looking for any items group that max and min value difference is minimum 
                if (temp_diff < diff )
                {
                    diff = temp_diff;
                    indx = i;
                }
            }
            int[] results = new int[totalToBeSelected];
            Array.Copy(values, indx, results, 0, totalToBeSelected);
            return results;
        }
