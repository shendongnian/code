    private bool CheckNewRecord(Control con)
    {
        var box = con as TextBox;
        if (!String.IsNullOrEmpty(box?.Text))
            return true;
        foreach (Control c in con.Controls)
        {
            box = c as TextBox;
            bool containsNonEmptyTextBox = !String.IsNullOrEmpty(box?.Text) || CheckNewRecord(c);
            if (containsNonEmptyTextBox)
                return true;
        }
        return false;
    }
