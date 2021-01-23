    public class Card
    {
        public string Content { get; set; }
        public override string ToString()
        {
            if (Content == null)
                return null;
            const int maxLength = 20;
            if (Content.Length > maxLength)
                return Content.Substring(0, maxLength - 1);
            return Content;
        }
    }
