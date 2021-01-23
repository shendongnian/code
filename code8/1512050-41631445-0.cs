    if (!ReferenceEquals(selectedlabel, null) && !string.IsNullOrEmpty(selectedlabel.Text))
    {
        if(!int.TryParse(selectedlabel.Text, out basketID))
        {
            // user entered text that is unconvertible to int
        }
    }
