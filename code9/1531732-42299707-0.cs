    output = System.Web.HttpContext.Current.Server.MapPath("/public/target.csv");
    
    string[] CSVDump = File.ReadAllLines(output);
    
    var CSV = CSVDump.Select(x => x.Split('|').ToList());
    
    var newInserted = CSV.Select(
    	x => { 
    			x.Insert(1, "NEW COLUMN");
    			return x;
    	});
