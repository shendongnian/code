    protected void rptTest_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        RadioButtonList rbl = (RadioButtonList)e.Item.FindControl("rblTest");
        rbl.SelectedIndexChanged += testFunction;
    }
