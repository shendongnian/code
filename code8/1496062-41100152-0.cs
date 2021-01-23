    private void SetComboIndex(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if(c is ComboBox)
            {
                ComboBox cb = (ComboBox)c;
                cb.SelectedIndex = -1;
            }
            SetComboIndex(c);
        }
    }
