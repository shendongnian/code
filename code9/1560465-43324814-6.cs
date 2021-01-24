    public void ShowDefaultDialog(string path)
    {
        System.Diagnostics.Process proc = new System.Diagnostics.Process();
        proc.EnableRaisingEvents = false;
        proc.StartInfo.FileName = "rundll32.exe";
        proc.StartInfo.Arguments = "shell32,OpenAs_RunDLL " + path;
        proc.Start();
    }
