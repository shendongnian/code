    public void PopulateList()
    {
       listBox.Items.Clear();
       using (System.IO.StreamReader sr = new System.IO.StreamReader(@"inventory.txt"))
            {
                while (!sr.EndOfStream)
                {
                    for (int i = 0; i < 22; i++)
                    {
                        string strListItem = sr.ReadLine();
                        if (!String.IsNullOrEmpty(strListItem) && 
                           (categoryComboBox.SelectedItem!=null &&     
                           (strListItem.Contains(categoryComboBox.SelectedItem.ToString())))
                        listBox.Items.Add(strListItem);
                    }
                }
            }
     }
