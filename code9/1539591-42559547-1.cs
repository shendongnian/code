    private bool CheckNewRecord(Control con)
    {
        var box = con as TextBox;
        if (!String.IsNullOrEmpty(box?.Text))
            return true;
        foreach (Control c in con.Controls)
        {
            var textBox = c as TextBox;
            if (!String.IsNullOrEmpty(box?.Text))
            {
                return true;
            }
            else
            {
                return CheckNewRecord(c);
            }
        }
        return false;
    }
