    DataTable dt = new DataTable();
    List<string> lines = new List<string>();
    var a = File.ReadAllLines("input.txt");
    foreach (var s in a)
    {
       lines.Add((s + "=" + dt.Compute(s, null)).Replace(" ", ""));       
    }
    File.WriteAllLines("output.txt", lines);
