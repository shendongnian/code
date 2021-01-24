    var selectedItemText =   new List<string>();
        foreach (var li in ListBox1.Items)
        {
           if (li.Selected == true)
            {
             selectedItemText.Add(li.Text);
            }
        }
