	string data = "4 Program Files (x86) 2";
	string LineID = "";
	string ParentID = "";
	string Content = "";
	List<string> values = new List<string>(data.Split(' '));
	if (values.Count >= 3)
	{
		LineID = values[0];
		ParentID = values[values.Count - 1];
		values.RemoveAt(0);
		values.RemoveAt(values.Count - 1);
		Content = String.Join(" ", values.ToArray());
	}
	Console.WriteLine("LineID = " + LineID);
	Console.WriteLine("ParentID = " + ParentID);
	Console.WriteLine("Content = " + Content);
