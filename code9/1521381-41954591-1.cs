    public class ArticleTag
    {
        public ArticleTag(int id, string tag)
        {
           Id = id;
           Tag = tag;
        }
        public int Id { get; private set; }
        public string Tag { get; private set; }
    }
