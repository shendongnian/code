    List<string> collection = new List<string> { "Item 1" };
    
    gridView.DataSource = collection ;
    
    gridView.DataBind();
    
    if (gridView.Rows.Count > 0)
    {
       gridView.SelectedIndex  = 0;
    }
