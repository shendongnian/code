		public void search_song(string txt_to_search)
		{
			foreach (var t in listbox_titles.Items)
			{
				
				if(txt_to_search.Occurrences(t.ToString(), false).Count > 0)
					MessageBox.Show(t.ToString());
			}
		}
	}
	static class StringHelpers
	{
		public static List<int> Occurrences(this string pattern, string source, bool caseSensitive = true)
		{
			List<int> occurs = new List<int>();
			if (String.IsNullOrEmpty(pattern) || String.IsNullOrWhiteSpace(pattern))
				return occurs;
			int index = 0;
			if (!caseSensitive)
			{
				pattern = pattern.ToLower();
				source = source.ToLower();
			}
			while (index < source.Length - 1)
			{
				if ((index = source.IndexOf(pattern, index)) < 0)
					break;
				occurs.Add(index);
				++index;
			}
			return occurs;
		}
	}
