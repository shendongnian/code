    public bool TryGetControl<T>(string name, out T control)
    {
        try
        {
            var children = RecurseChildren(this.MyUserControl);
            control = children
                .Where(x => Equals(x.Name, name))
                .OfType<T>()
                .First();
            return true;
        }
        catch
        {
            control = default(T);
            return false;
        }
    }
    public List<Control> RecurseChildren(DependencyObject parent)
    {
        var list = new List<Control>();
        var count = VisualTreeHelper.GetChildrenCount(parent);
        var children = Enumerable.Range(0, count - 1)
            .Select(x => VisualTreeHelper.GetChild(parent, x));
        list.AddRange(children.OfType<Control>());
        foreach (var child in children)
        {
            list.AddRange(RecurseChildren(child));
        }
        return list;
    }
