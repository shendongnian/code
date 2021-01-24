    static bool IsFocusedControlType<T>(Control control, out T focused)
        where T : Control
    {
        if (control is T t)
        {
            focused = t;
            return true;
        }
        var container = control as IContainerControl;
        while (container != null)
        {
            control = container.ActiveControl;
            if (control is T tt)
            {
                focused = tt;
                return true;
            }
            container = control as IContainerControl;
        }
        focused = null;
        return false;
    }
    static bool CanConsumeKey(Form sender, KeyEventArgs e)
    {
        if (IsFocusedControlType(sender, out NumericUpDown ud))
        {
            return false;
        }
        if (IsFocusedControlType(sender, out TextBox tb) && !tb.ReadOnly)
        {
            return false;
        }
        if (IsFocusedControlType(sender, out ListView lv) && lv.LabelEdit)
        {
            return false;
        }
        if (IsFocusedControlType(sender, out TreeView tv) && tv.LabelEdit)
        {
            return false;
        }
        if (IsFocusedControlType(sender, out ComboBox cb) && 
            cb.DropDownStyle != ComboBoxStyle.DropDownList)
        {
            return false;
        }
        return true;
    }
