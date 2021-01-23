    List<string> getParentNames(TreeNode node)
        {
            List<string> list = new List<string>();
            int count = getParentCount(node);
            int index = 0;
            TreeNode parent = node;
            while (index < count)
            {
                if (parent != null)
                {
                    index++;
                    list.Add(parent.Text);
                    parent = parent.Parent;
                }
            }
            return list;
        }
