    public  class Bes : player
    {
        public int MostRecentScore { get; private set; }
        public int TotalScore { get; private set; }
        public int AddScore(int score)
        {
            this.MostRecentScore = score;
            return this.TotalScore += score;
        }
    }
