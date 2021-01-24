    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            for (int i = 1; i <= Convert.ToInt32(Session["numberOfCountry"]); i++)
            {
                addControl(i);
            }
        }
        else
        {
            Session["numberOfCountry"] = "0";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(Session["numberOfCountry"]) + 1;
        Session["numberOfCountry"] = i;
        addControl(i);
    }
    private void addControl(int index)
    {
        TextBox tb = new TextBox();
        tb.ID = "CountryNext" + index;
        PlaceHolder1.Controls.Add(tb);
    }
