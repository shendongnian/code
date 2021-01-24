    public class StringItem
    {
        public static string[] LanguageNames
        {
            get { return new[] { "English", "German", "Spanish" }; }
        }
        public StringItem(string name)
        {
            Name = name;
            Languages = new Dictionary<string, string>();
            LanguageNames.ToList().ForEach(x => Languages.Add(x, null));
        }
        public string Name { get; private set; }
        public string Comment { get; set; }
        public Dictionary<string, string> Languages { get; set; }
    }
