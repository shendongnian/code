    public class Line : ViewModelBase
    {
        internal static Dictionary<string, string> DictionaryEngStub()
        {
            return new Dictionary<string, string>()
            {
                { "first_page_name ","First page" },
                { "second_page_name  ","Second page" }
            };
        }
        internal static Dictionary<string, string> DictionaryRuStub()
        {
            return new Dictionary<string, string>()
            {
                {"first_page_name ","Первая страница" },
                {"second_page_name  ","Вторая страница" }
            };
        }
        internal static Dictionary<string, string> DictionaryEng = new Dictionary<string, string>();
        internal static Dictionary<string, string> DictionaryRu = new Dictionary<string, string>();
        private string keyWord; 
        public string KeyWord
        {
            get { return keyWord;  }
            set
            {
                keyWord = value;
                OnPropertyChanged("keyWord");
            }
        }
        public string EnglishWord {
           get
            {
                string english;
                if (DictionaryEng.TryGetValue(keyWord ?? "", out english))
                {
                    return english;
                }
                return null;
            }
        }
        public string RussianhWord
        {
            get
            {
                string russian;
                if (DictionaryRu.TryGetValue(keyWord ?? "", out russian))
                {
                    return russian;
                }
                return null;
            }
        }
    }
