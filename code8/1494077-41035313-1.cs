    protected void Page_Load(object sender, EventArgs e)
    {
    	TextBox tb1 = new TextBox();
    	tb1.ID = "t1";    
    	tb1.Attributes.Add("runat", "server");
    	tb1.AutoPostBack = true;
    	addEvent(tb1,tb1.ID);
    	panel.Controls.Add(tb1);
    }
    
    private void addEvent(TextBox tb1,string id)
    {
    	tb1.TextChanged += (senders, eventArgs) =>
    	{
    		//do Something with the ID
    	};    
    }
     
