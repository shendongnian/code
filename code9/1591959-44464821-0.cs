	static void Main()
	{
		var randomCrap = new List<Object>
	{
		1, "two",
		new List<object> { 3, 4 },
		5, 6,
		new List<object> {
			new List<object> { 7, 8, "nine" },
		},
	};
	
		randomCrap.PrintAll();
	}
	
	public static class Extensions
	{
		public static void PrintAll(this Object root)
		{
			foreach (var x in root.SelectAll(0))
			{
				Console.WriteLine("{0}{1}", new string('_', x.indent),x.obj);
			}
		}
	
		public static IEnumerable<(Object obj,int indent)> 
                         SelectAll(this object o, int indent)
		{
			//  Thank you, eocron
			if (o is String)
			{
				yield return (o,indent);
			}
			else if (o is IEnumerable)
			{
				var e = o as IEnumerable;
				foreach (var child in e)
				{
					foreach (var child2 in child.SelectAll(indent+1))
						yield return child2;
				}
			}
			else
			{
				yield return (o, indent);
			}
		}
	}
