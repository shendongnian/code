    public interface IReference<TArticle> where TArticle : IArticle
    {
        Color Color { get; set; }
        TArticle Article { get; set; }
    }
