    private void showdetails()
    {
       //dataGridViewInventory.DataSource = null; 
       //dataGridViewInventory.Columns.Clear();
        var st= from a in db.productInvertoryTables
                 select a
        dataGridViewInventory.DataSource = st.ToList(); //Updated
        dataGridViewInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridViewInventory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
    
        var st1 = from k1 in db.cartTables
                  select k1;
        dataGridView2cart.DataSource = st1.ToList(); //Updated
        dataGridView2cart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridView2cart.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
    }
