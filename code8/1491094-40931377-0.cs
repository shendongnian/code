    void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                dataGridView1.Rows.Clear();
                string[] fileEntries = System.IO.Directory.GetFiles(treeView1.SelectedNode.Text);
                foreach (string fileName in fileEntries)
                {
                    
                    dataGridView1.Rows.Add(Path.GetFileName(fileName));
                }
            }
        }
