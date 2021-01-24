    private List<T> FindControls<T>(Control.ControlCollection controls) where T: Control
    {
        List<T> list = new List<T>();
        foreach (Control control in controls)
        {
            var matched = control as T;
            if (matched != null)
                list.Add(matched);
            else
                list.AddRange(FindControls<T>(control.Controls));
        }
        return list;
    }
