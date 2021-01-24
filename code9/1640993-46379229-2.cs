      public void search_song()
            {
        
                for (int i = listbox_titles.Items.Count - 1; i >= 0; i--)
                {
                    int char_count = listbox_titles.Items[i].ToString().Length;
                    if (listbox_titles.Items[i].ToString().Contains(txt_to_search.Text, StringComparison.OrdinalIgnoreCase)
                    {
                        //listbox_titles.SetSelected(i, true);
                        MessageBox.Show(listbox_titles.Items[i].ToString());
                    }
                }
