    protected void Page_Load(object sender, EventArgs e)
    {
        Dictionary<int, string> getStateName = new Dictionary<int, string>();
        getStateName.Add(3,"New York");
        getStateName.Add(2,"Chicago");
        getStateName.Add(1,"Washington");
        getStateName.Add(0,"Toronto");
        statename.DataSource = getStateName;
        statename.DataTextField = "Value";
        statename.DataValueField = "Key";   
    }
