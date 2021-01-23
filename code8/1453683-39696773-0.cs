     void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
     {
       GridView currentView = sender as GridView;
       if (e.Column.FieldName == "Customer")
       {
         bool value = Convert.ToBoolean(currentView.GetRowCellValue(e.RowHandle, "Flag_Customer"));
         if (value)
            e.Appearance.BackColor = Color.Red;
       }
        if (e.Column.FieldName == "Vendor")
        {
          bool value = Convert.ToBoolean(currentView.GetRowCellValue(e.RowHandle, "Flat_Vendor"));
          if (value)
            e.Appearance.BackColor = Color.Red;
        }
    }
