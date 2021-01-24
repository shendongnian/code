            public void XMLToTreeView()
            {
                var reader = XmlReader.Create(@"Path\Sample.xml");
                var xElement = XElement.Load(reader);
                reader.Close();
                findAllNodes(xElement, treeView1);
            }
    
            private void findAllNodes(XElement xElement, TreeView treeView)
            {
                TreeNode ParentNode = treeView.Nodes.Add(xElement.Attributes().FirstOrDefault().Value);
                foreach (XElement childElement in xElement.Elements())
                {
                    TreeNode node = new TreeNode();
                    node.Text = childElement.Attributes().FirstOrDefault().Value;
                    ParentNode.Nodes.Add(node);
                    findAllNodes(childElement, node);
                }
            }
    
            private void findAllNodes(XElement xElement, TreeNode node)
            {
                foreach (XElement childElement in xElement.Elements())
                {
                    TreeNode childNode = new TreeNode();
                    childNode.Text = childElement.Attributes().FirstOrDefault().Value;
                    node.Nodes.Add(childNode);
                    findAllNodes(childElement, childNode);
                }
            }
