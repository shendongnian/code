    public class DocumentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AlternativeTitle { get; set; }
        public ICollection<PageDto> Pages { get; set; }
        public string OriginalLanguage { get; set; }
        public string TranslationLanguage { get; set; }
    }
    public class PageDto
    {
        public int Id { get; set; }
        public string OriginalText { get; set; }
        public int Sorting { get; set; }
        public string Translation { get; set; }
    }
