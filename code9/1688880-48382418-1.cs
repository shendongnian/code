    private void saveNode2(TreeNodeCollection tnc)
    {
        foreach (TreeNode node in tnc)
        {
            if (node.Nodes.Count > 0)
            {
                xr.WriteStartElement(node.Text);
                saveNode2(node.Nodes);
                xr.WriteEndElement();
            }
            else 
            {
                **xr.WriteRaw($"<{node.Text}/>");**
            }
        }
