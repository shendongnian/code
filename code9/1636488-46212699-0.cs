    public static IEnumerable<T> GetControls<T>(this Control parent) where T : Control
    {
        foreach (Control control in parent.Controls)
        {
            if (control is T) yield return control as T;
            foreach (Control descendant in GetControls<T>(control))
            {
                if (control is T)
                    yield return descendant as T;
            }
        }
    }
