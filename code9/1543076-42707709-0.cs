    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostback)
        {
            return;
        }
        // Set here all the values that will be maintained by 'ViewState'
        Form.Attributes.Add("postback", "1");
        TextBox1.BackColor = System.Drawing.Color.Wheat;
    
        /* 
           Set runat="server" and enableviewstate="true" on common html elements 
           if you need to preserve it's values and styles between postbacks
        */
    }
