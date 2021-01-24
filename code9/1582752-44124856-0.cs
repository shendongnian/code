     class Program
        {
            static void Main(string[] args)
            {
                string[] arr1 = new string[] { "0", "2", "5", "7", "10", "11", null, "13", "15" };
                string[] arr2 = new string[] { "11", "13", "56", "8", null, "44", "55", "66", "77" };
                var v = arr1.Where(x => !String.IsNullOrEmpty(x)).Select(x => Double.Parse(x)).Where(x => (x % 5) == 0).Select((x, y) => new Test
                {
                    d1 = x,
                    d2 = Double.Parse(arr2.Where(c => !string.IsNullOrEmpty(c)).ToList()[y])
                });
            }
        }
