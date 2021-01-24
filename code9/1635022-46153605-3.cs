    private List<string> GetSelectedNames()
    {
        List<string> selectedNames = new List<string>();
        foreach (var item in treeView.Items.OfType<Node>())
            GetSelected(item, ref selectedNames);
        return selectedNames;
    }
    public void GetSelected(Node node, ref List<string> s)
    {
        if (node.IsChecked)
            s.Add(node.Name);
        foreach (Node child in node.Children)
            GetSelected(child, ref s);
    }
