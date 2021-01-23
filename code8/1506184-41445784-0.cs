    public class DVLTest : IDVLTest
    {
    
        private int wordCount = -1;
        public Word getRandomWord()
        {
            Random r = new Random();
            int i = r.Next(this.getDBWordsCount());
            return DVL_Entitie.Skip(i).Take(1);
        }
        private int getDBWordCount()
        {
            if(this.wordCount < 0)
            {
                this.wordCount = DVL_Entitie.Words.Count();
            }
            return this.wordCount;
        }
    
    }
