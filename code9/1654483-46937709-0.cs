    private void gridViewTest_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e) 
    {
        GridView gridView = sender as GridView; 
    
        if(gridView.FocusedColumn.FieldName == "Product Name") // && <PUT OTHER CONDITIONS HERE>
            e.Cancel = true;
    }
