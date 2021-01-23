        public bool CheckSentenceWithContinue(string rawMessage)
        {
            var lower = rawMessage.ToLower();
            var count = 0;
            foreach (WordFilter Filter in this._filteredWords.ToList())
            {
                if (!Filter.IsSentence)
                    continue; // Move on to the next filter, as this is not a senetece word filter
                if (!lower.Contains(Filter.Word))
                    continue; // Move on to the next filter, as the message does not contain this word
                
                // If you are here it means filter is a Sentence filter, and the message contains the word, so increment the counter
                count++;
            }
            return count >= 5;
        }
