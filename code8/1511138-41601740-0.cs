    protected override void OnInit(EventArgs e)
    {
    	List<CheckBox> cbList = new List<CheckBox>();
    	for (int i = 0; i < 10; i++)
    	{
    		CheckBox cb = new CheckBox();
    		cb.Text = "text" + i;
    		cb.ID = Guid.newGuid().ToString();
    		pnlEmailCheckboxes.Controls.AddAt(0, cb);
    		pnlEmailCheckboxes.Controls.AddAt(0, new LiteralControl("<br/>"));
    		cbList.Add(cb);
    	}
    
    	Session["checkboxes"] = cbList;
    }
