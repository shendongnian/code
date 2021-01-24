    private void dtgProductDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //For example:-
            //if(e.ColumnIndex == 0)
            if (e.ColumnIndex == "Put column index of Item Code.")
            {
                //Your function to bind values.
                //Searching of values in respect with Item Code from database.
                string ItemName="Value from db".
                string CostPrice="Value from db".
                string SalesPrice="Value from db".
                //Now put values in cells.
                //dtgProductDetail.Rows[e.RowIndex].Cells["Column Name"].Value = "Value to be inserted.";
                dtgProductDetail.Rows[e.RowIndex].Cells["Item Name"].Value = ItemName;
                dtgProductDetail.Rows[e.RowIndex].Cells["Cost Price"].Value = CostPrice;
                dtgProductDetail.Rows[e.RowIndex].Cells["Sales Price"].Value = SalesPrice;
            }
        }
