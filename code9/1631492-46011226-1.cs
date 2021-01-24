    void LoadTree(TreeNode treeNode, HtmlAgilityPack.HtmlNode rootNode)
            {
                foreach (var node in rootNode.ChildNodes)
                {
                    TreeNode n = new TreeNode(node.InnerText);
                    node.Attributes.Select(a => a.Name + "=" + a.Value)
                                   .ToList()
                                   .ForEach(x => n.Nodes.Add(x));
                    treeNode.Nodes.Add(n);
                    LoadTree(n, node);
                }
            }
