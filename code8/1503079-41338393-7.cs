        public bool CheckSentence(string rawMessage)
        {
            var lower = rawMessage.ToLower();
            var count = 0;
            foreach (WordFilter Filter in this._filteredWords.ToList())
            {
                if (lower.Contains(Filter.Word) && Filter.IsSentence)
                {
                    count++;
                }
            }
            return count >= 5;
        }
