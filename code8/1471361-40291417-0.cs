        private void cmbFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvContent.View = View.Details;
            lvContent.Items.Clear();
            lvContent.Columns.Clear();
            string[] content = File.ReadAllLines(@"Credentials/" + cmbFiles.SelectedItem);
            for (int i = 0; i < content.Length; i++)
            {
                string[] substrings = content[i].Split('|');
                if (i == 0)
                {
                    //create columns...
                    foreach (var item in substrings)
                    {
                        lvContent.Columns.Add(item);
                    }
                }
                else
                { 
                    //add datarow...
                    ListViewItem listItem1 = new ListViewItem(substrings[0]);
                    for (int j = 1; j < substrings.Count(); j++)
                    {
                        listItem1.SubItems.Add(new ListViewItem.ListViewSubItem(listItem1, substrings[j]));
                    }
                    lvContent.Items.Add(listItem1);
                }
            }
            lvContent.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
