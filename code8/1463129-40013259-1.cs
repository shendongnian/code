    DataTable dt = new DataTable();
    List<string> lines = new List<string>();
    var a = File.ReadAllLines("a.txt");
    foreach (var s in a)
    {
       lines.Add((s + "=" + dt.Compute(s, null)).Replace(" ", ""));       
    }
    File.WriteAllLines("b.txt", lines);
