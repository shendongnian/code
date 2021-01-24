    protected async void newfile(object fscreated, FileSystemEventArgs Eventocc)
    {
        try
        {
            await Task.Run(() =>
            {
                string CreatedFileName = Eventocc.Name;
                FileInfo createdFile = new FileInfo(CreatedFileName);
                string extension = createdFile.Extension;
                string eventoccured = Eventocc.ChangeType.ToString();
                fsLastRaised = DateTime.Now;
                string file = watchingFolder + "\\" + CreatedFileName;
                FileInfo info = new FileInfo(file);
                while (!IsFileReady(info)) { }
                printFile(file, extension);
            });
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show("Error");
        }
    }
