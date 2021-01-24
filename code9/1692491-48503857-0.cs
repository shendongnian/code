     private void Form1_Load(object sender, EventArgs e)
     {
           //Bind cell value changed event or set in designer.
           dgGridView.CellValueChanged += dgGridView_CellValueChanged;
     }
    
            private void dgGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex == -1) //-1 On load.
                    return;
    
                if (e.ColumnIndex > 0) //Only want to fire on the Item code column
                    return;
    
                var itemCodeEntered = dgGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
    
                var myBL = new MyBL();
                var itemData = myBL.GetItemData(itemCodeEntered);
    
                dgGridView.Rows[e.RowIndex].Cells[0].Value = itemData.ItemCode;
                dgGridView.Rows[e.RowIndex].Cells[1].Value = itemData.BarCode;
            }
