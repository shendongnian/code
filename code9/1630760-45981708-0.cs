    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable table = new DataTable();
        table.Columns.Add("fruits");
        table.Rows.Add("apple");
        table.Rows.Add("banana");
        table.Rows.Add("pineapple");
        table.Rows.Add("mango");
        table.Rows.Add("watermelon");
        table.Rows.Add("lemon");
        table.Rows.Add("guava");
        table.Rows.Add("jackfruit");
    
        var builder = new System.Text.StringBuilder();
    
        for (int i = 0; i < table.Rows.Count; i++)
            builder.Append(String.Format("<option value='{0}'>", table.Rows[i][0]));
        fruits.InnerHtml = builder.ToString();
        fruitsInput.Attributes["list"] = fruits.ClientID;
    }
