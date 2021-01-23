	List<object> types = new List<object>();
	types.Add(b);
	types.Add(c);
	foreach (var key in types)
	{
		if (key is Label)
		{
			((Label)key).FontSize = 10;
			((Label)key).Content = empIdNum;
		}
		if (key is TextBox)
		{
			((TextBox)key).FontSize = 10;
			((TextBox)key).Text = empIdNum.ToString();
		}
		if (key is TextBlock)
		{
			((TextBlock)key).FontSize = 10;
			((TextBlock)key).Text = empIdNum.ToString();
		}
	}
