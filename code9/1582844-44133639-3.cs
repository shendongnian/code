    class WordProvider : IQueryyProvider
    {
        private IQueryable<Word> allSonnetWords = null;
        private IQueryable<Word> GetAllSonnetWords()
        {
            if (allSonnetWords == null)
            {
                string sonnets = shakespeareDownLoader.DownloadSonnets();
                // split on whitespace:
                string[] sonnetWords = sonnets.Split((char[])null,
                    StringSplitOptions.RemoveEmptyEntries);
                
                this.allSonnetWords = sonnetWords
                    .Select(word => new Word() { Text = word })
                    .AsQueryable<Word>();
            }
        }
