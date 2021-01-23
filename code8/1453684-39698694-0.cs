     using DevExpress.XtraGrid.Views.Grid;
        // ... 
        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e) {
           GridView View = sender as GridView;
           GridView leftGridView = leftGrid.MainView as GridView; //It is up to you that which viewtype you have used.
           if(e.Column.FieldName == "Col5") {
              string srcVal= View.GetRowCellDisplayText(e.RowHandle, View.Columns["Col5"]); // You can use GetRowCellValue() method also to get the value from the cell.
              string leftGridVal= leftGridView .GetRowCellDisplayText(e.RowHandle, leftGridView .Columns["Col5"]);
              if(srcVal != leftGridVal) {
                 e.Appearance.BackColor = Color.DeepSkyBlue;
                 e.Appearance.BackColor2 = Color.LightCyan;
              }
           }
        }
