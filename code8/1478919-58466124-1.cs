    private void MyDataGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
    {
        //Because when creating the DataGridView, 
        //this event will be raised many times and we don't want to save that
        if (refreshing)
            return;
        
        //We make a dictionary to save each column order along with its name
        Dictionary<string, int> order = new Dictionary<string, int>();
        foreach (DataGridViewColumn c in dgvInterros.Columns)
        {
            order.Add(c.Name, c.DisplayIndex);
        }
        //Then we save this dictionary
        //Note that you can do whatever you want with it...
        using (FileStream fs = new FileStream(ColumnOrderFileName, FileMode.Create))
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, order);
        }
    }
