          dt.AutoGeneratingColumn += Dt_AutoGeneratingColumn;
     //....
     private void Dt_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
     {
         DataGridColumn col = e.Column;
         // you can set the maximum width of the column:
         col.MaxWidth = 200.0;
         // or you can define a element style, for text wrapping, etc.
         col.CellStyle = (Style)FindResource("cellStyle");
      }
