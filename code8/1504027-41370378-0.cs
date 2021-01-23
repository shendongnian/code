    public class ListArticle
    {
        public static List<string> Clothes { get; private set; }
        public static List<string> Colors { get; private set; }
        static ListArticle()
        {
            Clothes = new List<string>();
            Colors = new List<string>();
        }
    }
