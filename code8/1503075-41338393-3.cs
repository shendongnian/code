        public bool CheckSentenceLinq(string rawMessage)
        {
            var lower = rawMessage.ToLower();
            return _filteredWords
                       .Where(x => x.IsSentence)
                       .Count(x => lower.Contains(x.Word)) >= 5;
        }
