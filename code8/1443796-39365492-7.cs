    private void textBox_DEC_Search_TextChanged(object sender, EventArgs e)
    {
        // index is 0 if numeric for ID or 1 if not for NAME
        int ind = textBox_DEC_Search.Text.All(x => Char.IsNumber(x)) ? 0 : 1;
        List<ListViewItem> matchlist = new List<ListViewItem>();
        foreach(ListViewItem Items in listView_DEC_CustomerList.Items)
        {
            if(Items.SubItems[ind].Text.StartsWith(textBox_DEC_Search.Text) || 
              Items.SubItems[ind]Text.Contains(textBox_DEC_Search.Text))            
            {
                matchlist.Add(Items);
            }
        }
        // if you have found something add the all results
        if(matchlist.Any())            
        {
            listView_DEC_CustomerList.Items.Clear();
            listView_DEC_CustomerList.Items.AddRange(matchlist);
        }
    }
