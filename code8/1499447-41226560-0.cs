    public void AddItems(dynamic control, List<string> list)
    {
        foreach (string s in list)
            if (!control.Items.Contains(s))
                control.Items.Add(s);
    }
