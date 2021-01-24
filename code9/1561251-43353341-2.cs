    class Program
    {
      static void Main(string[] args)
      {
        Run(new Random());
        Console.ReadLine();
      }
      private static void Run(Random rnd)
      {
        var counts = new[] { 10, 100000, 10000000 };
        foreach (var count in counts)
        {
          Console.WriteLine(count);
          Run(count, rnd);
          Console.WriteLine();
        }
      }
      private static void Run(int count, Random rnd)
      {
        var values = GetValues(count, rnd);
        var funcs
          = new Dictionary<string, Func<string, int>>
          {
            {"OP", GetSignatureOP},
            {"Keith", GetSignatureKeith},
            {"Fun", GetSignatureFun},
          };
        foreach (var kvp in funcs)
        {
          TimeSpan elapsed;
          Test(values, kvp.Value, out elapsed);
          Console.WriteLine("{0,-5}: {1:G}", kvp.Key, elapsed);
        }
      }
      private static IList<string> GetValues(int count, Random rnd)
      {
        var result = new List<string>(count);
        for (int index = 0; index < count; index++)
        {
          result.Add(string.Format("<{0}>something here just not relevant</{0}>", rnd.Next(1, 10)));
        }
        return result;
      }
      private static int Test(IEnumerable<string> values, Func<string, int> func, out TimeSpan elapsed)
      {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        var sw = Stopwatch.StartNew();
        var count = values.Aggregate(0, (current, value) => current ^ func(value));
        sw.Stop();
        elapsed = sw.Elapsed;
        return count;
      }
      private static int GetSignatureOP(string value)
      {
        return Convert.ToInt32(value.Split('>')[0].Remove(0, 1));
      }
      private static int GetSignatureKeith(string value)
      {
        return int.Parse(value.Substring(1, value.IndexOf('>') - 1));
      }
      private static int GetSignatureFun(string value)
      {
        int result = 0;
        for (int i = 1; i < 12; i++)
        {
          if (value[i] == '>')
          {
            break;
          }
          result = (result * 10) + (value[i] - '0');
        }
        return result;
      }
    }
