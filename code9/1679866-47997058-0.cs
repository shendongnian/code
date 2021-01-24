    private void textBox1_TextChanged(object sender, EventArgs e)  //new 24-12-2017
            {
                var filteredItems = ListTreeViewItems.Where(item => item.Contains(textBox1.Text));
    
                List<string> FilterList = filteredItems.ToList();
    
           
                treeViewFilter.Nodes.Clear();           //remove all nodes
                foreach (object item in FilterList)     //Fill it again with only the filtered items
                {
                    TreeNode aNode = new TreeNode(item.ToString()) { Name = item.ToString() };  //THIS LINE IS THE SOLUTION
                    treeViewFilter.Nodes.Add(aNode);  
                }
    
                //zet de vinkjes weer terug
                foreach (string keepitem in KeepSelectedItems)  //Keep the items checked when filter starts
                {
                    
    
                    TreeNode[] arr = treeViewFilter.Nodes.Find(keepitem, true);
    
                    Logging.WriteToLog("", "treeViewFilter.Nodes.Find(keepitem, true); " + treeViewFilter.Nodes.Find(keepitem, true));
                   // Logging.WriteToLog("", "test " + test);
    
                    foreach (TreeNode s in arr)
                    {
                        treeViewFilter.SelectedNode = s;
                        s.Checked = true;
                    }
                }
    
                //check if empty the put the original list back
                if (textBox1.Text == string.Empty)  //park the checked items
                {
                    foreach (string item in KeepSelectedItems)
                    {
                        TreeNode[] arr = treeViewFilter.Nodes.Find(item, true);
                        foreach (TreeNode s in arr)
                        {
                            treeViewFilter.SelectedNode = s;
                            s.Checked = true;
                        }
                    }
                }
            }
