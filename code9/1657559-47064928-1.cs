            //Grab all the text from the RTF
            TextRange BobRange = new TextRange(
                    // TextPointer to the start of content in the RichTextBox.
                    Bob.Document.ContentStart,
                    // TextPointer to the end of content in the RichTextBox.
                    Bob.Document.ContentEnd
                );
            //Assume words are sperated by space, commas or periods, split on that and thorw the words in a List
            List<string> BobsWords = BobRange.Text.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            //Now use Linq for .net to grab what you want
            int CountOfTheWordThe = BobsWords.Where(w => w == "The").Count();
            //Now that we have the list of words we can create a MetaDictionary
            Dictionary<string, int> BobsWordsAndCounts = new Dictionary<string, int>();
            foreach( string word in BobsWords)
            {
                if (!BobsWordsAndCounts.Keys.Contains(word))
                    BobsWordsAndCounts.Add( word, BobsWords.Where(w => w == word).Count(); )
            }
