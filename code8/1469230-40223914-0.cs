    protected void Button1_Click(object sender, EventArgs e)
    {
        int rowCount = 0;
    
        //get the number from the textbox and try to convert to int
        try
        {
            rowCount = Convert.ToInt32(TextBox1.Text);
        }
        catch
        {
        }
    
        //set the new rowcount as a viewstate so it can be used after a postback
        ViewState["rowCount"] = rowCount;
    
        //start the function to fill the grid
        fillGrid();
    }
    
    private void fillGrid()
    {
        int rowCount = 0;
    
        //get the current row count from the viewstate
        if (ViewState["rowCount"] != null)
        {
            rowCount = Convert.ToInt32(ViewState["rowCount"]);
        }
    
        //create a new DataTable with three columns.
        DataTable table = new DataTable();
        table.Columns.Add("ID", typeof(int));
        table.Columns.Add("Name", typeof(string));
        table.Columns.Add("Created", typeof(DateTime));
    
        //loop to add the row to the table
        for (int i = 0; i < rowCount; i++)
        {
             table.Rows.Add(0, "Name_" + i.ToString(), DateTime.Now.AddMinutes(i));
        }
    
        //bind the table to the grid
        GridView1.DataSource = table;
        GridView1.DataBind();
    }
