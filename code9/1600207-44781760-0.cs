    public string Name_A { get; set; }
    
    public LoginSalesDetails(string Username, string AgentNo, string AgentName, string AgentPhone, string AgentEmail, int AgentRating)
    {
        InitializeComponent();
    
    
    
        accountname_label.Text = AgentName;
        agent_no_label.Text = AgentNo;
        rating_label.Text = "" + AgentRating;
        mobileno_label.Text = AgentPhone;
        email_label.Text = AgentEmail;
    
        Name_A = AgentName;
    
    
    //  DisplayAlert("Alert ", ""+AgentName, "OK");
    }
