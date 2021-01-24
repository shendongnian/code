    m_ListWorker = new FilesDataClass();
      
    for (int i = 0; i < 10; i++)
    {
        FilesDataStruct item = new FilesDataStruct();
        item.ID = i;
        item.Name = "Just_Testing";
    
        m_ListWorker.Files.Add(item);
    }
