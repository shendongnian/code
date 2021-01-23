    List<Double> line_list = new List<double>();
    foreach (string line in File.ReadLines("c:\\file.txt"))
	{
        string[] rows = line.Trim().Split(' ');
        foreach(string el in rows)
        {
            line_list.Add(double.Parse(el.Trim()));
        }
    }
