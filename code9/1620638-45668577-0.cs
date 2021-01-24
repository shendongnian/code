    if (filesList.SelectedItems[0].Tag.ToString() == "Folder")
    {
        string key = filesList.SelectedItems[0].Text;
        filesList.Clear();
        viewRoot = viewRoot[key].Children; // Set new view root
        //foreach (var item in nodes[key].Children) //Exception thrown here!
        foreach (var item in viewRoot) // iterate throught it
        {
            string fileName = Path.GetFileName(item.Key);
            string extension = Path.GetExtension(fileName);
            if (item.Value.Children.Count > 0)
            {
                ListViewItem itmNew = new ListViewItem(item.Key, 0);
                itmNew.Tag = "Folder";
                filesList.Items.Add(itmNew);
            }
            else
            {
                ListViewItem itmNew = new ListViewItem(item.Key, objIconListManager.AddFileIcon(fileName));
                itmNew.Tag = "File";
                filesList.Items.Add(itmNew);
            }
        }
    }
