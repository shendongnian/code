       public class LanguageViewModel
        {
            public int LanguageId { get; set; }
            public IEnumerable<Language> ActiveLanguages{get; set;}
        }
        
        public class Language
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
