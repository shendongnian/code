    using (ZipArchive archive = ZipFile.OpenRead(zipPath))
    {
         foreach (ZipArchiveEntry entry in archive.Entries)
         {
                 if (entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                 {
                      ListViewItem txtItem = new ListViewItem(entry.FullName);
                      txtItem .SubItems.Add(entry.LastWriteTime);
                      txtItem .SubItems.Add(entry.Length); //Uncompressed size
                      listView.Items.Add(txtItem);
                 }
         }
     } 
