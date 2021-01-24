    private bool CheckNewRecord(Control Con)
    {
        if(Con is TextBox && !String.IsNullOrEmpty(((TextBox)Con).Text))
            return true;
        foreach (Control C in Con.Controls)
        {
            if (C is TextBox && ((TextBox)C).Text != "")
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
