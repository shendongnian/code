    void ResetMySettings
    {
        // Method where settings are reset
        Properties.Settings.Default.Reset();
        // Set value of SaveDir
        CheckSaveDirValue();
    }
    ...
    private void CheckSaveDirValue()
    {
        Settings.Default.SaveDir = 
            Directory.Exists(Settings.Default.SaveDir)
            ? Settings.Default.SaveDir
            : Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    }
