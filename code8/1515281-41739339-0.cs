     private void MyDataGrid_AutoGenerateColumn(
    object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "fieldname")
            {
                e.Cancel = true;
            }
        }
   
