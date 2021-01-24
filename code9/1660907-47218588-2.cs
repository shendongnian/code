    public interface IPhrase
    {
        string PhraseId { get; set; }
        int CategoryId { get; set; }
        string English { get; set; }
        string Romaji { get; set; }
        string Kana { get; set; }
        string Kanji { get; set; }
        int Modified { get; set; }
        bool Favorite { get; set; }
        string WordType { get; set; }
        bool Hidden { get; set; }
        int OneHash { get; set; }
        int TwoHash { get; set; }
        int? FrequencyA { get; set; }
        int? FrequencyB { get; set; }
        int? FrequencyC { get; set; }
        int? JapaneseForBusyPeople { get; set; }
        int? AJlpt { get; set; }
        int? TJlpt { get; set; }
        bool Selected { get; set; }
    }
