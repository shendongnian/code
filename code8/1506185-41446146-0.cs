    public List<string> getWords(int wrNum)
            {
                IDVLTest d3 = new DVLTest();
                Random r = new Random();
                for (int i = 0; i < wrNum;i++ )
                {
                    string word = d3.getRandomWord(r).Text;
    
                    Words.Add(new WordView { Word = word, Status = WordStatus.Right });
                }
                return Words.Select(w=>w.Word).ToList();
            }
    
     public class DVLTest:IDVLTest
        {
    private int wordCount = -1;
            private List<Word> DBWords;
    
            public DVLTest()
            {
                DBWords = DVL_Entitie.Words.ToList();
            }
    
            public Word getRandomWord(Random r)
            {
                int i = r.Next(getDBWordCount());
                return DBWords.ElementAt(i);
            }
    
            private int getDBWordCount()
            {
                if (this.wordCount < 0)
                {
                    this.wordCount = DVL_Entitie.Words.Count();
                }
                return this.wordCount;
            }
    }
