        Dictionary<string, string> yourValues = new Dictionary<string, string>();
        foreach (Control x in this.Controls)
        {
            if (x is TextBox)
            {
                yourValues.Add(((TextBox)x).Name, ((TextBox)x).Text);
            }
        }
