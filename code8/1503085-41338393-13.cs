        public bool CheckSentenceLinq(string rawMessage)
        {
            var lower = rawMessage.ToLower();
            return _filteredWords
                       .Where(x => x.IsSentence)
                       .Where(x => lower.Contains(x.Word))
                       .Skip(5)
                       .Any();
        }
