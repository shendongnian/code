        public void PrintNodesRecursive(UltraTreeNode oParentNode)
        {
            if (oParentNode.Nodes.Length == 0)
            {
                return;
            }
            foreach (UltraTreeNode oSubNode in oParentNode.Nodes)
            {
                if(oSubNode.Visible)
                {
                    MessageBox.Show(oSubNode.Key.ToString());
                }
                PrintNodesRecursive(oSubNode);
            }
        }
