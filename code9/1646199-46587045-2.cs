     public static T[] Permute<T>(int input, List<T> items)
        {
            List<T> brute = new List<T>();
            while (true)
            {
                var temp = (decimal)input / (decimal)items.Count;
                var r = input % items.Count;
                input = (int)temp-1;
                if (temp < 1)
                {
                    brute.Add(items[r]);
                    break;
                }
                else
                {
                    brute.Add(items[r]);
                }
            }
            return brute.ToArray();
        }
