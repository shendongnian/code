    public static partial class Program 
	{
		static void Main(string[] args)
		{
			DictionaryCount<int, string> dict = new DictionaryCount<int, string>();
			dict.CountLessThan += dict_TryRemove;
			dict.CountToFireOn = 1;
			dict.TryAdd(1, "hello");
			dict.TryAdd(2, "world");
			dict.TryAdd(3, "!");
			string outValue;
			dict.TryRemove(2, out outValue);
			dict.TryRemove(1, out outValue);
			Console.ReadKey(true);
		}
		
		private static void dict_TryRemove(object sender, CountEventArgs e)
		{
			DictionaryCount<int, string> dict = sender as DictionaryCount<int, string>;
			Console.WriteLine(dict.Count);
			Console.WriteLine("Count less than 2!");
		}
				
		public class DictionaryCount<TKey, TValue> : ConcurrentDictionary<TKey, TValue>
		{
			public int CountToFireOn { get; set; }
			
			public DictionaryCount() : base() { }
			
			public delegate void CountEventHandler(object sender, CountEventArgs e);
			public event CountEventHandler CountLessThan;
			
			public new bool TryRemove(TKey key, out TValue value)
			{
				bool retVal = base.TryRemove(key, out value);
				if (this.Count <= CountToFireOn)
				{
					CountEventArgs args = new CountEventArgs(this.Count);
					CountLessThan(this, args);
				}
				return retVal;
			}
		}
		public class CountEventArgs
		{
			public int Count { get; set; }
			
			public CountEventArgs(int count)
			{
				this.Count = count;
			}
		}
	}
