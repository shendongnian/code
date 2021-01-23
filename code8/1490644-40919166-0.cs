    public ActionResult DownloadUsersDates()
    {
    	byte[] data = Encoding.UTF8.GetBytes(GetAllDates());
        var res = Encoding.UTF8.GetPreamble().Concat(data).ToArray();
        return File(res, "text/csv", "DatesList.csv");
    }
    
    public string GetAllDates()
    {
        var sb = new StringBuilder();
        const string separater = ",";
        const string columnEscaper = "\"";
    
        sb.Append("Date");
    
        //Doing some code...
    
        foreach (var item in myItems)
        {
             sb.Append(columnEscaper);
             sb.Append((item.BirthDate.ToString("yyyy-MM-dd"))); //returns dates of format: `YYYY-MM-DD`
             sb.Append(columnEscaper);
             sb.Append(separater);
             sb.Append("\r");
        }
    	
    	string output=sb.ToString();
    
        if (output.Contains(",") || output.Contains("\""))
        output = '"' + output.Replace("\"", "\"\"") + '"';
    	
        return output;
    }
