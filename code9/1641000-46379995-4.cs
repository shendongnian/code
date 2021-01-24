		public void search_song(string txt_to_search)
		{
			foreach(var t in listbox_titles.Items)
			{
				String s = t.ToString().ToLower();
				if(s.Contains(txt_to_search.ToLower()))
				{
					//listbox_titles.SetSelected(i, true);
					MessageBox.Show(s);
				}
			}
		}
