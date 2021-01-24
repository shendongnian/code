    protected void btnadd_Click(object sender, EventArgs e)
    {
        int num;
        num = Convert.ToInt32(txtnumber.Text.Trim());
        int addedColumn = Convert.ToInt32(columnAdded.Value);
        for (int i = addedColumn + 1; i <= addedColumn + num; i++)
        {
            string name = "t";
            name = string.Concat(name, i);
            BoundField test = new BoundField();
            test.HeaderText = name;
            GridView1.Columns.Add(test);
    
        }
        columnAdded.Value = addedColumn + num;
    }
