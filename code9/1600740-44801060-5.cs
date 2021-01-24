    private void OnSaveAs()
    {
        SaveFileDialog save = new SaveFileDialog();
        save.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        if (save.ShowDialog() == true)
        {
            using (FileStream S = File.Open(save.FileName, FileMode.CreateNew))
            {
                using (StreamWriter st = new StreamWriter(S))
                {
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
        }
    }
