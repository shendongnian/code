    var sb = new StringBuilder();
    sb.Capacity = 16; // default, adjust it to less number as you wish
    
    foreach (String line in System.IO.File.ReadLines(HttpContext.Server.MapPath("~/content/data.csv")))
    {
        sb.Append(line);	
    }
    
    ViewData.Add("file", sb.ToString());
