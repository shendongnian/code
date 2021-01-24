    output = System.Web.HttpContext.Current.Server.MapPath("/public/target.csv");
    
    string[] CSVDump = File.ReadAllLines(output);
    
    var CSV = CSVDump.Select(x => x.Split('|').ToList());
    var newInserted = CSV.Aggregate(new List<List<String>>(), (l, i) =>
	{
		i.Insert(1, (l.Count == 0) ? "header" : "fileName");
		l.Add(i);
		return l;
	});
    File.WriteAllLines(output, newInserted.Select(x => string.Join("|", x)));
