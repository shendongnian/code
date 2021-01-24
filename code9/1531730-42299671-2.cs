    // define the desired position here:
    int posNewColumn = 2;
    output = System.Web.HttpContext.Current.Server.MapPath("/public/target.csv");
    
    string[] CSVDump = File.ReadAllLines(output);
    List<List<string>> CSV = CSVDump.Select(x => x.Split('|').ToList()).ToList();
    for (int i = 0; i < CSV.Count; i++)
    {
        CSV[i].Insert(posNewColumn , i == 0 ? "Headername" : "Filename");
    }
    File.WriteAllLines(output, CSV.Select(x => string.Join("|", x)));
