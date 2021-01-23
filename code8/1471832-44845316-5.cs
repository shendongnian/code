     public void BuildTree(TreeView treeView, XDocument doc)
        {
            TreeViewItem treeNode = new TreeViewItem
            {
                //Should be Root
                Header = doc.Root.Name.LocalName,
                IsExpanded = true
            };
            treeView.Items.Add(treeNode);
            BuildNodes(treeNode, doc.Root);
        }
        public void BuildNodes(TreeViewItem treeNode, XElement element)
        {
            foreach (XNode child in element.Nodes())
            {
                switch (child.NodeType)
                {
                    case XmlNodeType.Element:
                        XElement childElement = child as XElement;
                        XElement prev = child.PreviousNode as XElement;
                        if(childElement.Name == "dl" && prev.Name == "h3")
                        { 
                        
                            TreeViewItem childTreeNode = new TreeViewItem
                            {
                                //because only the dl nodes have child nodes we want 
                                //to display the dl nodes with the inner text of thier respective previous node
                                Header = prev.Value
                            };
                            treeNode.Items.Add(childTreeNode);
                            BuildNodes(childTreeNode, childElement);
                        }
                        break;
                    case XmlNodeType.Text:
                        XText childText = child as XText;
                        treeNode.Items.Add(new TreeViewItem { Header = childText.Value, });
                        break;
                }
            }
        }
