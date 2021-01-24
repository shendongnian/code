		static void CheckWords( String[] words, HashSet<String> valid )
		{
			//Horizontal
			foreach( var w in words )
				FindWords( w, valid );
			
			//Vertical
			String word = "";
			for( int i = 0; i < words.Length; i++ )
			{
				for( int j = 0; j < words[i].Length; j++ )
					word += words[j][i];
				
				FindWords( word, valid );
				word = "";
			}
			
			//Diagonal
			String word2 = "";
			for( int i = 0, j = 0; i < words.Length; i++, j++ )
			{
				word += words[i][j];
				word2 += words[i][words[i].Length - i - 1];
			}
			
			FindWords( word, valid );
			FindWords( word2, valid );
					
		}
		static void FindWords( String word, HashSet<string> valid )
		{
			int len = word.Length;
			//Generate all possible (left to right) substring for String with Length - a [ FOr example, for "MAKE" we can have possible values for "MAKE", "MAK", "MA", "M", "AKE", "KE", "K, "E", "A
			for( int a = 0; a < len; a++ )
			{
				//Find all possible substring with this length { k = 1, k = 2, k = 3, ..., k = word.Length }
				for( int k = 1; k <= word.Length; k++ )
				{
					Match match = new Regex(@"([A-Za-z]{" + k + "}){1}").Match(word);
					//For all found groups, we just care for the first group wich contains the main unrepeated substrings
					for( int i = 0; i < match.Groups.Count - 1; i++ )
						for( int j = 0; j < match.Groups[i].Captures.Count; j++ ) //Check each permutation for each word with K length. You can Console.Write each value to check it's generated string
							if( valid.Contains( match.Groups[i].Captures[j].Value ) )
								Console.WriteLine( match.Groups[i].Captures[j].Value );
				}
				word = word.Substring( 1, word.Length - 1 );
			}
		}
