    public static IEnumerable<T> GetControlsOfType<T>(Control root)
        where T : Control
    {
        var t = root as T;
        if (t != null)
            yield return t;
    
        var container = root as ContainerControl;
        if (container != null)
            foreach (Control c in container.Controls)
                foreach (var i in GetControlsOfType<T>(c))
                    yield return i;
    }
