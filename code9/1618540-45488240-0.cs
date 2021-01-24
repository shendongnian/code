    private IEnumerable<T> GetViewsByType<T>(ViewGroup root) where T : View
    {
        var children = root.ChildCount;
        var views = new List<T>();
        for (var i = 0; i < children; i++)
        {
            var child = root.GetChildAt(i);
            if (child is T myChild)
                views.Add(myChild);
            else if (child is ViewGroup viewGroup)
                views.AddRange(GetViewsByType<T>(viewGroup));
        }
        return views;
    }
