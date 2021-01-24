    public static bool ContainsNonEmptyTextBox(Control con)
    {
        var controlQueue = new Queue<Control>();
        controlQueue.Enqueue(con);
        while (controlQueue.Count > 0)
        {
            Control current = controlQueue.Dequeue();
            TextBox txt = current as TextBox;
            if (!String.IsNullOrEmpty(txt?.Text))
                return true;
            foreach (Control c in current.Controls)
                controlQueue.Enqueue(c);
        }
        return false;
    }
