    List<string> input = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ViewState["messages"] != null)
        {
            input = (List<string>)ViewState["messages"];
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        List<string> msgs = new List<string>() { "1", "2", "3" };
        ViewState["messages"] = msgs;
    }
