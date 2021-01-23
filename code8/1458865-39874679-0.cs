    foreach (var value in Enum.GetValues(typeof(Color)).Cast<Color>())
    {
        listView1.Items.Add(new ListViewItem() 
                     {
                         Name = value.ToString(),
                         Text = value.ToString(),
                         Checked = entity1.SelectedColors.HasFlag( value ),
                         Tag = value
                      });
    }
