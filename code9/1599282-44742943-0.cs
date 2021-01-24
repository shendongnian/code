           public KeyValuePair<Boolean, TreeNode> SearchChildren(TreeNode node, string key)
            {
                if (node.Nodes.ContainsKey(key))
                {
                    return new KeyValuePair<bool, TreeNode>(true, node.Nodes[key]);
                }
                else
                {
                    foreach (TreeNode child in node.Nodes)
                    {
                        if (child.Nodes != null)
                        {
                            KeyValuePair<Boolean, TreeNode> results = SearchChildren(child, key);
                            if (results.Key)
                            {
                                return results;
                            }
                        }
                    }
                }
                return new KeyValuePair<bool, TreeNode>(false, null);
            }
