    protected void Page_Load(object sender, EventArgs e)
    {
        //check if the viewstate exists and if so, build the controls
        if (ViewState["boxCount"] != null)
        {
            buildControls(Convert.ToInt32(ViewState["boxCount"]));
        }
    }
    
    protected void button1_Click(object sender, EventArgs e)
    {
        //adding controls moved outside the button click in it's own method
        try
        {
            buildControls(Convert.ToInt32(text_number.Text));
        }
        catch
        {
        }
    }
    
    protected void button2_Click(object sender, EventArgs e)
    {
        //check if the viewstate exists and if so, build the controls
        if (ViewState["boxCount"] != null)
        {
            int n = Convert.ToInt32(ViewState["boxCount"]);
    
            //loop al controls count stored in the viewstate
            for (int i = 0; i < n; i++)
            {
                TextBox control = FindControl("newtext_" + i) as TextBox;
                mylist.Add(control.Text);
            }
        }
    }
    
    private void buildControls(int n)
    {
        //clear the panel of old controls
        mypanel.Controls.Clear();
    
        for (int i = 0; i < n; i++)
        {
            TextBox MyTextBox = new TextBox();
            MyTextBox.ID = "newtext_" + i;
            MyTextBox.CssClass = "textblock";
            mypanel.Controls.Add(MyTextBox);
    
            Literal lit = new Literal();
            lit.Text = "<br />";
            mypanel.Controls.Add(lit);
        }
    
        //save the control count into a viewstate
        ViewState["boxCount"] = n;
    }
