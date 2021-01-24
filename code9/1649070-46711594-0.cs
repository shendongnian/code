    BackgroundColourEntry.TextChanged += (sender, e) => 
    {
        var entry = sender as Entry;
        if (string.IsNullOrEmpty(entry.Text))
        {
            entry.BackgroundColor = Color.Red;
        } 
        else
        {
            entry.BackgroundColor = Color.Green;
        }
    };
