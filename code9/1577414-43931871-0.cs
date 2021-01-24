    public interface ITranslatable {
        string TranslationKey { get; }
        string TranslatedProperty { get; set; }
    }
    class MyEntity : ITranslatable {
        public string TranslationKey { get; set; }
        public string Description { get; set; }
        // implicit implementation to avoid clutter
        string ITranslatable.TranslatedProperty
        {
            get { return Description; }
            set { Description = value; }
        }
    }
