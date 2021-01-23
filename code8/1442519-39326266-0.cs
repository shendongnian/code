    linqToSqlDataContext z = new linqToSqlDataContext();
            var st= (from a in z.productInvertoryTables
                              select a).ToList();
            dataGridViewInventory.DataSource = st;
            dataGridViewInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewInventory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridViewInventory.Refresh();
