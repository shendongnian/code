    public interface IReference<TArticle> where TArticle : IArticle
    {
        Color Color { get; set; }
        TArticle Article { get; set; }
    }
    public class Paint : IReference<PaintType>
    {
        public virtual Color Color { get; set; }
        public virtual PaintType Article { get; set; }
    }
