    private void ExpandTree(int Depth)
    {
        tr.CollapseAll();
        foreach (TreeNode tn in tr.AllNodes().Where(tn => tn.Depth < Depth))
        {
            tn.Expand();
        }
    }
