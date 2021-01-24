     private void addTreeNode(XmlNode xmlNode, TreeNode treeNode)
            {
                **char[] karakter = new char[] { '<', '>', '/' };**
                XmlNode xNode;
                TreeNode tNode;
                XmlNodeList xNodeList;
                if (xmlNode.HasChildNodes) //The current node has children
                {
                    xNodeList = xmlNode.ChildNodes;
                    for (int x = 0; x <= xNodeList.Count - 1; x++)
                    {
                        xNode = xmlNode.ChildNodes[x];
                        treeNode.Nodes.Add(new TreeNode(xNode.Name));
                        tNode = treeNode.Nodes[x];
                        addTreeNode(xNode, tNode);
                    }
                }
                else
                {
                    treeNode.Text = xmlNode.OuterXml.Trim(**karakter**);
                }
