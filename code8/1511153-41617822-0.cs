    protected void btnEmail_Click(object sender, EventArgs e)
    {
        List<CheckBox> cbList = new List<CheckBox>();
        for (int i = 0; i < 10; i++)
        {
            CheckBox cb = new CheckBox();
            cb.Text = "text" + i;
    
            //cb.ID = Guid.newGuid().ToString(); //don't do this.
            cb.ID = "checkbox" + i; // <------ do this, have a consistent ID
    
            cb.ClientIDMode = ClientIDMode.Static;
            pnlEmailCheckboxes.Controls.AddAt(0, cb);
            pnlEmailCheckboxes.Controls.AddAt(0, new LiteralControl("<br/>"));
            cbList.Add(cb);
        }
    
        Session["checkboxes"] = cbList;
        mpeEmail.Show();
    }
