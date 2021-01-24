    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
              var query = from p in db.Items_
                        where p.itemCode== this.mydatagrid.CurrentCell.Value.ToString();
                        select p;
            this.mydatagrid.Rows.Clear();
            foreach (var items in query)
            {
                mydatagrid.Rows.Add(
                                             items.barcode.ToString(),
                                             items.itemName.ToString(),
                                             items.quantity.ToString(),
                                             items.rate.ToString()
                                             //etc
                    );
            }
            }
            catch
            {
            }
            
        }
