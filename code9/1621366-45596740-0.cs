    double[] a = { 2.122, 3.665, 4.917 };
    double[][] c = m_CO.Process(cc);
    var usCulture = new CultureInfo("en-US");
    // Using a list to build the string is more efficient than += every time
	var tmpList = new List<string>();
	foreach (var l1 in c) // l1 is double[]
	{
		foreach (var l2 in l1) // l2 is double
		{
            // Specify en-US culture since many cultures use "," instead of "." for decimal separator
			tmpList.Add(l2.ToString(usCulture));
		}	
	}
    lblText.Text = string.Join(", " , tmpList);
	tmpList.Clear();
