    void CreateFileLink(string absoluteFilePath)
    {
        linkPdfLabel_.Text = Path.GetFileName(absoluteFilePath);
    
        var link = new LinkLabel.Link();
        link.LinkData = absoluteFilePath;
        linkPdfLabel_.Links.Add(link);
    }
    void linkPdfLabel__LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process process = new Process();
        process.StartInfo.FileName = (string)linkPdfLabel_.Link[0].LinkData;
        process.Start();
    }
