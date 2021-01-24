	public static IEnumerable<SomeObject> convert(this IEnumerable<SomeObject> input)
	{
		var finished = input.FirstOrDefault(x => x.Status == "Finished");
		if (finished != null)
		{
			return new List<SomeObject> {finished};
		}
	   return input.Aggregate(new List<SomeObject>(), (a, b) =>
	   {
		   if (!a.Any())
		   {
	   		  a.Add(b);
		   }
		   else if (b.Status == "Open")
		   {
			  if (a.Last().Status == "Closed")
			  {
     			a.Remove(a.Last());
			  }
			  a.Add(b);
		   }
		   else if (b.Status == "Closed")
		   {
			  a = new List<SomeObject> {b};
		   }
		   return a;
	   });
	}
