    public void RunTest()
    {
        Test t = new Stackoverflow.Form1.Test();
        Console.WriteLine(t.Values.First());
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine(t.Values.First());
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine(t.Values.First());
        Console.WriteLine("------");
        Console.WriteLine(t.Values2.First());
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine(t.Values2.First());
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine(t.Values2.First());
        Console.WriteLine("------");
        Console.WriteLine(t.Values3.First());
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine(t.Values3.First());
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine(t.Values3.First());
    }
    public class Test
    {
        public IEnumerable<string> Values { get; set; } = GetValues();
        public static IEnumerable<string> GetValues()
        {
            List<string> results = new List<string>();
            for (int i = 0; i < 10; ++i)
            {
                yield return DateTime.UtcNow.AddMinutes(i).ToString();
            }
        }
        public IEnumerable<string> Values2 { get; set; } = GetValues2();
        public static IEnumerable<string> GetValues2()
        {
            return GetValues().ToList();
        }
        public IEnumerable<string> Values3 { get; set; } = GetValues().ToList();
    }
