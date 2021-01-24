    public static int ConsecutiveSumArrangements(int[] vals, int count, int sum)
        {
            var number = 0;
            for (int i = 0; i < (vals.Length - count); i++)
            {
                var segSum = vals.Skip(i).Take(count).Sum();
                if (segSum == sum)
                {
                    number++;
                }
            }
            return number;
        }
