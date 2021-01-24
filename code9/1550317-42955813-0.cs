    public static void SetDraggable(this Control c)
    {
            c.MouseDown += c_MouseDown;
            c.MouseMove += c_MouseMove;
            control = c;
    }
