     private void Form1_Load(object sender, EventArgs e)
     {
           //Bind cell value changed event or set in designer.
           dgGridView.CellValueChanged += dgGridView_CellValueChanged;
     }
    
        private void dgGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (e.ColumnIndex > 0)
                return;
            var myBL = new MyBL();
    
            switch (e.ColumnIndex)
            {
                case 0: //Item Code Column
                    var itemCodeEntered = dgGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    var itemData = myBL.GetItemData(itemCodeEntered);
                    dgGridView.Rows[e.RowIndex].Cells[0].Value = itemData.ItemCode;
                    dgGridView.Rows[e.RowIndex].Cells[1].Value = itemData.BarCode;
                    break;
                case 1: //Bar code column
                    // Do other stuff here.
                    break;
                //etc...
            }
        }
