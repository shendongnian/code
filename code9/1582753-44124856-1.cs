     class Program
        {
            static void Main(string[] args)
            {
                string[] arr1 = new string[] { "0", "2", "5", "7", "10", "11", null, "13", "15" };
                string[] arr2 = new string[] { "11", "13", "56", "8", null, "44", "55", "66", "77" };
              var v = arr1
                       .Zip(arr2, (x, y) => new { x, y })
                       .Where(a => !string.IsNullOrEmpty(a.x) && !string.IsNullOrEmpty(a.y))
                       .Select(a => new Test { d1 = double.Parse(a.x), d2 = double.Parse(a.y) })
                       .Where(a => (a.d1 % 5) == 0);
            }
        }
