    int ? selectedRow = null;
    
    public void LoadList()
    { 
    
    // reset global variable 
    selectedRow = null;
    
    List<string> collection = new List<string> { "Item 1" };
        
    gridView.DataSource = collection ;
        
    if (gridView.Rows.Count = 1)
    {
      selectedRow = 0;
    }
    
    }
