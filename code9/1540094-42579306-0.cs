    // store here all your values later
    List<string> allvalues = new List<string>();
    private void frmPOS_Load(object sender, EventArgs e)
    {
    
        // all your DB stuff...
    
        // here are my example values
        // NOTE! your values might be separated differently!
        allvalues.Add("ItemCode,ItemName,Price,Stocks");
        allvalues.Add("ItemCode2,ItemName2,Price2,Stocks2");
        allvalues.Add("ItemCode3,ItemName3,Price3,Stocks3");
        allvalues.Add("ItemCode4,ItemName4,Price4,Stocks4");
    
    
        AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
        // corresponds to your rdr.GetString(1) command
        Collection.Add("ItemName");
        Collection.Add("ItemName2");
        Collection.Add("ItemName3");
        Collection.Add("ItemName4");
    
        txtITEMNAME.AutoCompleteCustomSource = Collection;
        txtITEMNAME.AutoCompleteSource = AutoCompleteSource.CustomSource;
        txtITEMNAME.AutoCompleteMode = AutoCompleteMode.SuggestAppend;        
    }
