           public KeyValuePair<Boolean, TreeNode> SearchChildren(TreeNode node, string key, Boolean root)
            {
                if (!root)
                {
                    if(node.Nodes.ContainsKey(key)) return new KeyValuePair<bool, TreeNode>(true, node.Nodes[key]);
                }
                foreach (TreeNode child in node.Nodes)
                {
                    if (child.Nodes != null)
                    {
                        KeyValuePair<Boolean, TreeNode> results = SearchChildren(child, key, false);
                        if (results.Key)
                        {
                            return results;
                        }
                    }
                }
                return new KeyValuePair<bool, TreeNode>(false, null);
            }
