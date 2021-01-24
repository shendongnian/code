    // btnrecprefresh_Click method
    string[] files = Directory.GetFiles(@"C:\test", "*.txt", SearchOption.AllDirectories);
    foreach (string f in files)
    {
    	string entry = Path.GetFileName(f);
    	var item = new ListBoxItem() { Content = entry, Tag = f };
    	listbox.Items.Add(item);
    }
    // Listbox_SelectedIndexChanged method
    var selectedItem = listbox.SelectedItem as ListBoxItem;
    string path = selectedItem.Tag.ToString();
    MessageBox.Show(path);
