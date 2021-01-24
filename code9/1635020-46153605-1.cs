    public Node getTree(DirectoryInfo di)
    {
        Node item = new Node();
        item.Name = di.Name;
        foreach (DirectoryInfo s in di.GetDirectories())
        {
            item.Children.Add(getTree(s));
        }
        foreach (FileInfo fi in di.GetFiles())
        {
            item.Children.Add(new Node { Name = fi.Name });
        }
        return item;
    }
