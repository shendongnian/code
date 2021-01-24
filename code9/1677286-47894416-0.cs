	using System;
	using System.Linq;
	using Newtonsoft.Json;
					
	public class Program
	{
		static public T JsonDeserialize<T>(string input, T example)
		{
			return JsonConvert.DeserializeObject<T>(input);
		}
	
		public static void Main()
		{
			const string input = @"[ { 'id' : 12, 'data' : 'MyData' }, { 'id' : 13, 'data' : 'Another record' } ]";
	
			var example = new []
					{
						new { id = default(int), data = default(string) }
					};
			
			
			var list = JsonDeserialize(input, example);
	
			foreach ( var o in list.Where( a => a.id == 12))
			{
				Console.WriteLine(o.id);
				Console.WriteLine(o.data);
			}
			
			
		}
	}
