    public class Phrase
    {
        public string PhraseId { get; set; }
        public int CategoryId { get; set; }
        public string English { get; set; }
        public string Romaji { get; set; }
        public string Kana { get; set; }
        public string Kanji { get; set; }
        public int Modified { get; set; }
        public bool Favorite { get; set; }
        public string WordType { get; set; }
        public bool Hidden { get; set; }
        public int OneHash { get; set; }
        public int TwoHash { get; set; }
        public int? FrequencyA { get; set; }
        public int? FrequencyB { get; set; }
        public int? FrequencyC { get; set; }
        public int? JapaneseForBusyPeople { get; set; }
        public int? AJlpt { get; set; }
        public int? TJlpt { get; set; }
        public bool Selected { get; set; }
    }
    
    public class Score
    {
        public int EnglishCorrect { get; set; }
        public int KanaCorrect { get; set; }
        public int RomajiCorrect { get; set; }
        public int KanjiCorrect { get; set; }
    }
    
    public class ScoredPhrase
    {
        public Phrase Phrase { get; set; }
        public Score Score { get; set; }
    }
