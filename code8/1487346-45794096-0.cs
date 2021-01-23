      private void trvAcsConfig_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                //get selected tree node
                TreeNode selectedTreeNOde = ((TreeView)sender).SelectedNode;
                string fullPath = "/" + selectedTreeNOde.FullPath.Replace("\\", "/");
                //selected tree node is an attribute, comment,... 
                if (selectedTreeNOde.Nodes.Count == 0)
                    fullPath = fullPath.Substring(0, fullPath.LastIndexOf('/'));
                
                XmlNodeList nodes = AcsConfig.ConfigXmlDocument.SelectNodes(fullPath);
                
                Console.WriteLine(selectedTreeNOde.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
