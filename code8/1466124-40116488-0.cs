           using (StreamWriter sw = File.CreateText(DirectoryPath))
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    sw.Write(item.Text + ": ");
                    for (int i = 1; i < item.SubItems.Count; i++)
                    {
                        sw.WriteLine(item.SubItems[i].Text);
                    }
                }
             }
