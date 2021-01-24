    using System;
    using System.Windows.Forms;
    private void BrowserForDirectory()
    {
        FolderBrowserDialog dirDialog = new FolderBrowserDialog();
            using (var dummy = new Form() { TopMost = true })
            {
                if (dirDialog.ShowDialog(dummy.Handle))
                {
                    importfolder = dirDialog.SelectedPath;
                }
            }
    }
