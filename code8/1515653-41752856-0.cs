    private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e) {
       GridView view = sender as GridView;
       qChanged = Convert.ToBoolean(view.GetRowCellDisplayText(e.RowHandle, View.Columns["QuantityChanged "]));
    if (qChanged == true)
     e.Appearance.BackColor = Color.Red;
    }
