	public class Program
	{
		public static void Main()
		{
			var teams = new Dictionary<string, List<string>>();
			teams.Add("Short List",  new List<string> {"One","Two"});
			teams.Add("Medium List", new List<string> {"One","Two", "Three"});
			teams.Add("Long List",   new List<string> {"One","Two", "Three", "Four"});
			
			foreach (var kvp in teams.OrderByDescending(x => x.Value.Count))
			{
				Console.WriteLine("Team {0} has {1} items.", kvp.Key, kvp.Value.Count);
			}
		}
	}
