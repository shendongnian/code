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
            //Sample data with two records
			const string input = @"[ { 'id' : 12, 'data' : 'MyData' }, { 'id' : 13, 'data' : 'Another record' } ]";
	
            //Create an example instance so the compiler can use its anonymous type
			var example = new []
					{
						new { id = default(int), data = default(string) }
					};
			
			
	        //Pass the example as argument 2 so that the compiler can infer T. The argument itself isn't used for anything.
            var list = JsonDeserialize(input, example);
	
            //Now we have a strongly-typed list, without having to write a class
            //We can use LINQ or anything else that needs a strong type
			foreach ( var o in list.Where( a => a.id == 12) )
			{
				Console.WriteLine(o.id);
				Console.WriteLine(o.data);  //Intellisense works here
			}
			
			
		}
	}
