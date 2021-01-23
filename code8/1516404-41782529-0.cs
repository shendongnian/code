	class Program
	{
		static void Main(string[] args)
		{
			Array januaryData = Enum.GetValues(typeof(FebruaryMonth));
			Array.Sort(januaryData, new FebruaryMonthSubstringComparer());
			for (int i = 0; i < januaryData.Length; i++)
			{
				string res = string.Format("On {0}:Temperature was{0:D}<br/>", januaryData.GetValue(i));
				Console.WriteLine(res);
			}
		}
	}
	public class FebruaryMonthSubstringComparer : IComparer
	{
		public int Compare(object x, object y)
		{
			int monthX = int.Parse(Enum.GetName(typeof(FebruaryMonth), x).Substring(3)); // Naive parsing
			int monthY = int.Parse(Enum.GetName(typeof(FebruaryMonth), y).Substring(3));
			return monthX - monthY;
		}
	}
