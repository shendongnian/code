    List<string> textboxNames = new List<string>();
    List<string> textboxValues = new List<string>();
    foreach (var c in this.Controls)
    {
        if (c is TextBox)
        {                   
            textboxNames.Add((c as TextBox).Name);
            textboxValues.Add((c as TextBox).Text);
        }
    } 
