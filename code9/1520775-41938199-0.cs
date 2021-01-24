	public class Key : IEquatable<Key>
    {
        public string Param1 { get; set; }
        public string Param2 { get; set; }
        public int Param3 { get; set; }
        public bool Equals(Key other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Param1, other.Param1) && string.Equals(Param2, other.Param2) && Param3 == other.Param3;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Key) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Param1 != null ? Param1.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Param2 != null ? Param2.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Param3;
                return hashCode;
            }
        }
    }
    static class Program
    {
        static void TestClass()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var classDictionary = new Dictionary<Key, string>();
            for (var i = 0; i < 10000000; i++)
            {
                classDictionary.Add(new Key { Param1 = i.ToString(), Param2 = i.ToString(), Param3 = i }, i.ToString());
            }
            stopwatch.Stop();
            Console.WriteLine($"initialization: {stopwatch.Elapsed}");
            stopwatch.Restart();
            for (var i = 0; i < 10000000; i++)
            {
                var s = classDictionary[new Key { Param1 = i.ToString(), Param2 = i.ToString(), Param3 = i }];
            }
            stopwatch.Stop();
            Console.WriteLine($"Retrieving: {stopwatch.Elapsed}");
        }
        static void TestTuple()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var tupleDictionary = new Dictionary<Tuple<string, string, int>, string>();
            for (var i = 0; i < 10000000; i++)
            {
                tupleDictionary.Add(new Tuple<string, string, int>(i.ToString(), i.ToString(), i), i.ToString());
            }
            stopwatch.Stop();
            Console.WriteLine($"initialization: {stopwatch.Elapsed}");
            stopwatch.Restart();
            for (var i = 0; i < 10000000; i++)
            {
                var s = tupleDictionary[new Tuple<string, string, int>(i.ToString(), i.ToString(), i)];
            }
            stopwatch.Stop();
            Console.WriteLine($"Retrieving: {stopwatch.Elapsed}");
        }
        static void Main()
        {
            TestClass();
			TestTuple();
		}
	}
