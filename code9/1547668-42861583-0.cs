    List<string> clientType = new List<string>()
    {
        nameof(Customer),
        nameof(TimeWaster)
    };
    
    public frmClientScreen()
    {
        cmboxClientType.DataSource = clientType;
    }
