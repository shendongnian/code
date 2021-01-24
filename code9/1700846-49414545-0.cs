        int x = 0;
        
        foreach (var t in getTweets)
        {
            ListViewItem listItem = new ListViewItem(t.Text);
            listItem.SubItems.Add(t.CreatedBy.ScreenName.ToString());
            listItem.SubItems.Add(t.CreatedAt.ToString());
            listItem.SubItems.Add(t.FavoriteCount.ToString());
            listItem.SubItems.Add(t.RetweetCount.ToString());
            listView1.Items.Add(listItem);
            listView1.Items[x].Tag = t.Id;
            
            x = x +1;
        }
