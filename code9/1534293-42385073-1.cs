    List<IDirDetails> data = LoadData();                   
    int totalRecords = data.Count;
    
    if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
    {
        // Apply search
        data = data.OfType<DirectoryItemInfo>().Where(p => p.FileName.ToString().ToLower().Contains(search.ToLower()) ||  
                               p.FileSize.ToLower().Contains(search.ToLower()) ||               
                               p.FileModified.ToString().ToLower().Contains(search.ToLower())).Cast<IDirDetails>().ToList(); 
    }   
