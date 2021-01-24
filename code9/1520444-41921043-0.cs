	public class DictionaryComparer : IEqualityComparer<Dictionary<string, string>>
	{
		public int GetHashCode(Dictionary<string, string> d)
		{
			var hashCode = 17;
			foreach (var entry in d.OrderBy(kvp => kvp.Key))
			{
				hashCode = hashCode * 23 + entry.Key.GetHashCode();
				hashCode = hashCode * 23 + entry.Value.GetHashCode();
			}
			
			return hashCode;
		}
		
		public bool Equals(Dictionary<string, string> d1, Dictionary<string, string> d2)
		{
			string value2;
			return d1.Count == d2.Count && d1.All(kvp => d2.TryGetValue(kvp.Key, out value2) && kvp.Value == value2);
		}
	}
