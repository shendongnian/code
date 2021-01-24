    void CreateLink(string absoluteFilePath)
    {
        _linkPdfLabel_.Tag = absoluteFilePath;
        _linkPdfLabel_.Text = Path.GetFileName(absoluteFilePath);
    }
    
    void linkPdfLabel__LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process process = new Process();
        process.StartInfo.FileName = (string)linkPdfLabel_.Tag;
        process.Start();
    }
