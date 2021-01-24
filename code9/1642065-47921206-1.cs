    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack || X.IsAjaxRequest)
            return;
    
        store.DataSource = new object[] 
        { 
            new { Field1 = "Row 1" },
            new { Field1 = "Row 2" },
            new { Field1 = "Row 3" }
        };
    
        store.DataBind();
    }
    
    protected void Store_ReadData(object sender, StoreReadDataEventArgs e)
    {
        comboStore.DataSource = new object[] 
        { 
            new { Key = DateTime.Now.ToString("d/M/yyyy"), Display = "d/M/yyyy" },
            new { Key = DateTime.Now.ToString("dd-MMM-yyyy"), Display = "dd-MMM-yyyy" }
        };
    
        comboStore.DataBind();
    }
    
