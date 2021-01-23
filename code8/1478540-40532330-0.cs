            var listItem = new ListItem(/* arguments */);
            listItem.BackColor = Color.Yellow; // Debugging only
            listItem.Margin = Padding.Empty;
            listItem.Size = panel.Size;
            listItem.Click += SetListItemColor;
