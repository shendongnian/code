    private void Activate()
    {
        if (!IsActivated())
        {
            var filePath = GetActivatedFilePath();
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.Create(filePath);
        }
    }
    private bool IsActivated()
    {            
        return File.Exists(this.GetActivatedFilePath());
    }
        
    private void Deactivate()
    {
        if (IsActivated())
        {
            File.Delete(GetActivatedFilePath());
        }
    }
