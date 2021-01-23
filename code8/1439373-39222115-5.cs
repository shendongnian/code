        private void TreeNodeStrcutureManually(XmlDocument x)
        {
        TreeNode level1 = new TreeNode();
        TreeNode level2 = new TreeNode();
        TreeNode level3 = new TreeNode();
        XmlNodeList nl = x.SelectNodes("DOC");
        XmlNode root = nl[0];
        foreach (XmlNode xnode in root.ChildNodes)
        {
            string level = xnode.LastChild.InnerText;
            switch (level)
            {
                case " 1 ":
                    level1 = treeView1.Nodes.Add(level);
                    break;
                case " 2 ":
                    level2 = level1.Nodes.Add(level);
                    break;
                case " 3 ":
                    level3 = level2.Nodes.Add(level);
                    break;
                default:
                    break;
            }
        }
    }
