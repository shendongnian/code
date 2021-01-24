    foreach (DataRow dr in dt.Rows)
            {
                if (!UserFunctions.IsNullOrEmpty(traceWindow.traceTreeView.Nodes.Find(dr["PARENT_NODE"].ToString(), true)))
                {
                    // add child to parent
                    // if child_node == null -> cNode.Name(Text) = "INDATA"
                    TreeNode cNode;
                    // "JOB_NAME_IN" is a column name in the database
                    if (!string.IsNullOrEmpty(dr["JOB_NAME_IN"].ToString()))
                    {
                        cNode = new TreeNode(dr["JOB_NAME_IN"].ToString());
                    }
                    else
                    {
                        cNode = new TreeNode(dr["INDATA"].ToString());
                    }
                    // .Name is the key of that node. 
                    // Setting it to child node allows me to search for which node is the parent of the current datarow i'm reading.
                    cNode.Name = dr["CHILD_NODE"].ToString();
                    TreeNode[] pNode = traceWindow.traceTreeView.Nodes.Find(dr["PARENT_NODE"].ToString(), true);
                                        
                    pNode[0].Nodes.Add(cNode);
                }
                else
                {
                    // There is no child, create new parent
                    // if child_node == null -> cNode.Name(Text) = "INDATA"
                    TreeNode pNode;
                    if (!string.IsNullOrEmpty(dr["JOB_NAME_IN"].ToString()))
                    {
                        pNode = new TreeNode(dr["JOB_NAME_IN"].ToString());
                    }
                    else
                    {
                        pNode = new TreeNode(dr["INDATA"].ToString());
                    }
                    pNode.Name = dr["CHILD_NODE"].ToString(); // Key
                    traceWindow.traceTreeView.Nodes.Add(pNode);
                }
            }
