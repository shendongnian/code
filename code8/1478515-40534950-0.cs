    class Verse
    {
        public int Number { get; set; }
        public string Text { get; set; }
    }
    class Chapter
    {
        public int Number { get; set; }
        public Dictionary<int, Verse> Verses { get; set; }
    }
    class Book
    {
        public string Name { get; set; }
        public Dictionary<int, Chapter> Chapters { get; set; }
    }
    class Bible
    {
        public string Version { get; set; }
        public Dictionary<string, Book> Books {get; set;}
    }
