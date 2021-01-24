	string divider = "|___";
	Func<IEnumerable<MyClass>, int, IEnumerable<string>> output = null;
	output = (items, n) =>
		items
			.SelectMany(item =>
				new []
				{
					"".PadLeft(
						divider.Length * (n - 1 > 0 ? n - 1 : 0))
						+ (n > 0 ? divider : "")
						+ item.ID
				}.Concat(output(item.Children, n + 1)));
