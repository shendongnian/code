    string fromDateQS = Request.QueryString["FromDate"];
    DateTime dt = new DateTime();
    
    if (DateTime.TryParse(fromDateQS, out dt))
    {
    	System.Diagnostics.Debug.WriteLine(dt.ToString("mm-dd-yyyy"));
    }
