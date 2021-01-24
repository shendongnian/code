    /// <summary>
    /// Load CheckedListBox from database table
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form1_Load(object sender, EventArgs e)
    {
    
        var ops = new Operations();
    
        // read data from database table
        var dt = ops.GetAll();
    
        int LastIndex = 0;
    
        /*
            * Here we iterate the rows in the DataTable while in
            * CoursesCodeSample I set the DataSource of the CheckedListBox
            * to the DataTable. The method shown here has always been the
            * way to go as many indicated that since the DataSource property
            * of the CheckedListBox is not documented it could go away, well
            * many years later it's still here so guess what, it's okay.
            */
        foreach (DataRow row in dt.Rows)
        {
            checkedListBox1.Items.Add(new CheckListBoxItem()
            {
                Description = row.Field<string>("Description"),
                PrimaryKey = row.Field<int>("id"),
                Quantity = row.Field<int>("Quantity"),
                IsDirty = false
            });
    
            LastIndex = checkedListBox1.Items.Count - 1;
            checkedListBox1.SetItemChecked(LastIndex, row.Field<bool>("CheckedStatus"));
    
        }
    
        checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;
    
    }
