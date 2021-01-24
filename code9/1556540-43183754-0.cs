    public ActionResult Add(string date = null)
    {
        DateTime startTime = DateTime.Now;
    
        if (date != null)
        {
            startTime = DateTime.Parse(Uri.UnescapeDataString(date));
        }
    }
    
