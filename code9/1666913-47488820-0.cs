    public partial class Translation
    {
        public Guid DerivedId { get; set; }
        public Guid? Word1 { get; set; }
        public Guid? Word2 { get; set; }
        public Word Word1Navigation { get; set; }
        public Word Word2Navigation { get; set; }
    }
    public partial class Word
    {
        public Word()
        {
            TranslationWord1Navigation = new HashSet<Translation>();
            TranslationWord2Navigation = new HashSet<Translation>();
        }
        public Guid Id { get; set; }
        public ICollection<Translation> TranslationWord1Navigation { get; set; }
        public ICollection<Translation> TranslationWord2Navigation { get; set; }
    }
