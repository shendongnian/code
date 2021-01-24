    List<string> Questions;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["questions"] != null)
        {
            Questions = Session["questions"] as List<string>;
        }
        else
        {
            Questions = new List<string>();
            Session["questions"] = Questions;
        }
    }
