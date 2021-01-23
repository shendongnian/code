    TextBox tb1 = new TextBox();
    tb1.ID = "t1";    
    tb1.Attributes.Add("runat", "server");
    tb1.AutoPostBack = true;
    tb1.TextChanged += new EventHandler(t1_TextChanged);
    panel.Controls.Add(tb1);
    protected void t1_TextChanged(object sender, EventArgs e)
    {
        //do Something
    }
