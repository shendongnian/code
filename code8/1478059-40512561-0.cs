	List<object> types = new List<object>();
	types.Add(b);
	types.Add(c);
	foreach (var key in types)
	{
		if (key.GetType() == typeof(Label))
		{
			((Label)key).FontSize = 10;
			((Label)key).Content = empIdNum;
		}
		if (key.GetType() == typeof(TextBox))
		{
			((TextBox)key).FontSize = 10;
			((TextBox)key).Text = empIdNum.ToString();
		}
		if (key.GetType() == typeof(TextBlock))
		{
			((TextBlock)key).FontSize = 10;
			((TextBlock)key).Text = empIdNum.ToString();
		}
	}
