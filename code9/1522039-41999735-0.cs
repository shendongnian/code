    public DataAccessLayer(string path)
    {
        _path = Path.GetFullPath(path);
        _connectionPath = _path + @"\MyDatabase.sqlite";
        
        using (var db = new MediaContext(_connectionPath))
        {
            db.Database.ExecuteSqlCommand("CREATE TABLE IF NOT EXISTS 'MediaModels' ('Name' TEXT, 'FilePath' TEXT NOT NULL PRIMARY KEY, 'Tags' TEXT, 'Note' TEXT, 'FileExtension' TEXT)");
    
            db.SaveChanges();
        }
    }
        
    public void Generate()
    {
        using (var db = new MediaContext(_connectionPath))
        {
            db.MediaModels.Add(new MediaModel("test"));
            db.SaveChanges();
        }
    }
