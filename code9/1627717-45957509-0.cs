    void PopulateFolders()
            {                  
                int callLvl = 1;
                BuildInfaCmd(InfaCmdType.ListFolders);    
                
                int timeout = 60000;
                if (lstProjects.SelectedItem.ToString().ToLower().StartsWith("hdp"))
                    timeout = 600000;
    
                InfaCmd icmd = CallInfaCmd(InfaCmdExe, InfaCmdArgs,null,timeout);    
    
                if (icmd.ExitCode() == 0)
                {
                    List<string> folders = icmd.GetFolders();
    
                    foreach (string f in folders)
                    {
                        TreeNode p = new TreeNode(f);
                        treeView1.Nodes.Add(p);
                        PopulateFoldersRecursive(f, p, 1);
                    }
    
                    lstFolders.DataSource = folders;
                }
                else
                {
                    MessageBox.Show(icmd.GetError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
    void PopulateFoldersRecursive(string folder, TreeNode node, [Optional]int callLevel)
            {
                int timeout = 60000;
                if (lstProjects.SelectedItem.ToString().ToLower().StartsWith("hdp"))
                    timeout = 600000;
                int callLvl = callLevel;
                string fold = "";                
                try
                {                   
                    
                    BuildInfaCmd(InfaCmdType.ListFolders, folder);
                    InfaCmd icmd = CallInfaCmd(InfaCmdExe, InfaCmdArgs,null, timeout);     
                    if (icmd.ExitCode() == 0)
                    {
                        List<string> folders = icmd.GetFolders();                               
    
                        if (folders.Count > 0)
                            topFolderFound = true;
    
                        foreach (string f in folders)
                        {                            
                                callLvl += 1;
                                //MessageBox.Show("Calling recursive " + callLvl.ToString());                            
    
                                TreeNode p = new TreeNode(f);
                                node.Nodes.Add(p); // Add to calling node as children
                                                   // MessageBox.Show(callLvl.ToString() + "; Node.text : " + node.Text + " ;  f : " + f);
                                dirTree.Add(p.FullPath);
                                if (String.IsNullOrEmpty(folderFullPath))
                                {
                                    //fold = node.Text + "/" + f; // The sub-folder to be provided to ListFolder command like -p /RootFolder/SubFolder1/SubFolder2/...
                                    fold = folder + "/" + f; // ORIGINAL                                   
                                    folderFullPath = fold;
                                }
                                else
                                {                                   
                                    
                                    fold = folder + "/" + f; // TEST
                                    
                                    folderFullPath = fold; // ORIGINAL
                                }
    
                                PopulateFoldersRecursive(fold, p, callLvl);
                            }
                        }
                    }
    
                    else
                    {
                        MessageBox.Show(icmd.GetError(), "Error while executing InfaCmd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }    
    
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException, "Error");
                }
    
            }
