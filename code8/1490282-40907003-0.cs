    ListView.Items.AddRange(ListData.Where(i =>    
                string.IsNullOrEmpty(searchBox.Text) 
                || i.ID.StartsWith(searchBox.Text))
                .Select(c => new ListViewItem // this part
                   {
                       Name = c.ID.ToString(),
                       Text = c.Name + " " + c.LastName
                   }).ToArray());
