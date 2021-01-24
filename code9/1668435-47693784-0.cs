    foreach (DataRow dr in dt.Rows)
            {
                // Look to see if the current datarow (dr) has a parent already in the tree. If so add this as a child.
                if (!UserFunctions.IsNullOrEmpty(traceWindow.traceTreeView.Nodes.Find(dr["PARENT_NODE"].ToString(), true)))
                {
                    //Print("CHILD");
                    // add child to parent
                    TreeNode cNode = new TreeNode(dr["JOBB_NAMN"].ToString());
                    TreeNode[] pNode = traceWindow.traceTreeView.Nodes.Find(dr["PARENT_NODE"].ToString(), true);                    
                    pNode[0].Nodes.Add(cNode);
                }
                else // This is a parent node
                {
                    //Print("PARENT");
                    // There is no child, create new parent
                    TreeNode pNode = new TreeNode(dr["JOBB_NAMN"].ToString());
                    pNode.Name = dr["PARENT_NODE"].ToString();
                    traceWindow.traceTreeView.Nodes.Add(pNode);
                }
