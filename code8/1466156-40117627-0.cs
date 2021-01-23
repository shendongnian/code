	private static IEnumerable<Foo> GetAllFoosFILO(Foo foo)
	{
		foreach (var c in ((IEnumerable<Foo>)foo.Children).Reverse())
		{
			var cc = GetAllFoosFILO(c);
			foreach (var ccc in cc)
			{
				yield return ccc;
			}
			yield return c;
		}
	}
