    protected void Page_Load(object sender, EventArgs e)
    {
        //create fake data for demo and bind to repeater
        var data = Enumerable.Range(0, 10).Select(i => new { test = "foo " + i });
        rep.DataSource = data;
        rep.DataBind();
    }
    public string Trim2Chars(object input)
    {
        string inputString = input as string;
        if (inputString == null)
            return "";
        if (inputString.Length < 2)
            return inputString;
        return inputString.Substring(2);
    }
