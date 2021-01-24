		   string s = "A block of text is text that is grouped together in some way, such as with the use of paragraphs or";
           string wordtoSearch = "block";
           int firstfound = s.IndexOf(wordtoSearch);
		 
		    // If the index of the first letter found is greater than 100, get the 100 letters before the found word and 100 letters after the found word
            if (firstfound > 100)
            {
                string before = s.Substring(firstfound , firstfound-100);
                string after = s.Substring(firstfound + wordtoSearch.Length, 100);
				Console.WriteLine(before);
		        Console.WriteLine(after);
            }
		//// If the index of the first letter found is less than 100, get the letters before the found word and 100 letters after the found word 
		    if(firstfound < 100)
			{
				string before = s.Substring(0, firstfound);
				Console.WriteLine(before);
				if(s.Length >100)
				{
                string after = s.Substring(firstfound + wordtoSearch.Length, 100);
				Console.WriteLine(after);
				}
				else
				{
					string after = s.Substring(firstfound + wordtoSearch.Length);
		            Console.WriteLine(after);
				}
			}
		
