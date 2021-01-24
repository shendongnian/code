    lines = File.ReadAllLines(System.Web.HttpContext.Current.Server.MapPath("/public/" + keys.ToString() + ".csv"));
    rows = lines.Count();
    
    int i = 0;
    foreach (string line in lines)
    {
        string[] parts = line.Split('|');
        foreach (string part in parts)
        {
            columns = parts.Count();
        }
        i++;
    }
    Response.Write("Number of rows/columns = " + rows.ToString() + "/" + columns.ToString());
    Response.End();
