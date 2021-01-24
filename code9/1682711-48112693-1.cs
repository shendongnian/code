     TreeNode[] parents = treeView.Nodes.Find(l.Key, true);
     TreeNode node = new TreeNode(l.Follow, l.Letter);  
     node.Tag = l;
     for (int i = 0; i < parents.Length; i++)
     {
         parents[i].Nodes.Add(node);
     }
