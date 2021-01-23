    private void ShowFileDetails()
    {
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.Multiselect = false;
        ofd.ShowDialog();
        System.IO.FileInfo fi = new FileInfo(ofd.FileName);
        MessageBox.Show(string.Format("Extension={0}\nFile Name={1}\nFile Size={2} bytes\nFile Path={3}\nCreated On={4}\nModified On={5}", 
                                fi.Extension, 
                                fi.Name, 
                                fi.Length, 
                                fi.FullName,
                                fi.CreationTime,
                                fi.LastWriteTime),"File Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
