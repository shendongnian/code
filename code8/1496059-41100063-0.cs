    foreach (Control cnl in Controls)
    {
        if(cnl is ComboBox)
        {
           ComboBox cb = (ComboBox)cnl;
           cb.SelectedIndex = -1;
        }
    }
