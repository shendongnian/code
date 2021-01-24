        private string englishSaved;
        public string EnglishWord {
           get
            {
                if (englishSaved != null)
                {
                    return englishSaved;
                }
                string english;
                if (DictionaryEng.TryGetValue(keyWord ?? "", out english))
                {
                    return english;
                }
                return null;
            }
            set
            {
                englishSaved = value; //save the new translation into a persistence layer
            }
        }
