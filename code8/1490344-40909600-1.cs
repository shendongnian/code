    protected void Page_Load(object sender, EventArgs e)
    {
        //check if the viewstate exists and if so, build the controls
        if (ViewState["controlCount"] != null)
        {
            addControls(Convert.ToInt32(ViewState["controlCount"]));
        }
        else
        {
            //if not add just 1 control
            addControls(1);
        }
    }
    
    private void addControls(int n)
    {
        //loop the amount of controls and add them to the placeholder
        for (int i = 0; i < n; i++)
        {
            UserControl1 control = (UserControl1)LoadControl("~/UserControl1.ascx");
            PlaceHolder1.Controls.Add(control);
        }
    
        //save the control count into a viewstate
        ViewState["controlCount"] = PlaceHolder1.Controls.Count;
    }
    
    protected void AddControl_Click(object sender, EventArgs e)
    {
        //add an extra control
        addControls(1);
    }
