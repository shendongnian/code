    protected void Page_Load(object sender, EventArgs e)
    {
        string theProdId = GetProdIDFromQstring("rvdsfpid");
    }
    public static string GetProdIDFromQstring(string lookFor)
    {
        string retval = string.Empty;
        string url = HttpContext.Current.Request.Url.AbsoluteUri;//get the url
        List<string> urlParts = url.Split('/').ToList();//split the url parts
        int fieldPosition = urlParts.FindIndex(p => p == lookFor);//find where your target is
        if (fieldPosition > -1)//if the field exists
        {
        retval = urlParts[fieldPosition + 1].Split('-').Last();//get the last part of this splitted string
        }
        return retval;
    }
