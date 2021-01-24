     public static T[] Permute<T>(int input, List<T> items)
        {
            List<T> Brute = new List<T>();
            while (true)
            {
                var temp = (decimal)input / (decimal)items.Count;
                var r = input % items.Count;
                input = (int)temp-1;
                if (temp < 1)
                {
                    Brute.Add(items[r]);
                    break;
                }
                else
                {
                    Brute.Add(items[r]);
                }
            }
            return Brute.ToArray();
        }
