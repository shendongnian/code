    var st= from a in db.productInvertoryTables
            select a;
    var bindinglist = new BindingList<ProductInvertoryTable>(st.ToList()); 
    dataGridViewInventory.DataSource = bindinglist;
    dataGridViewInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    dataGridViewInventory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
