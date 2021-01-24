    private void OnSaveAs()
    {
        SaveFileDialog save = new SaveFileDialog();
        save.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        if (save.ShowDialog() == true)
        {
            FileStream fileStream = File.Open(save.FileName, FileMode.CreateNew);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            // Iterate over ListBox elements
            foreach (var myListBox in MyListBoxes)
            {
                // Write the name of the ListBox element
                streamWriter.WriteLine(myListBox.Name);
                // Write the number of elements
                streamWriter.WriteLine(myListBox.Items.Count);
                // Write the elements
                foreach (var item in myListBox.Items)
                {
                    streamWriter.WriteLine(item.ToString());
                }
            }
        }
    }
