    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            index = (int)Session["index"];
            if (index == 5)
            {
                totallyagree.Checked = true;
            }
            else if (index == 4)
            {
                agree.Checked = true;
            }
        }
    }
