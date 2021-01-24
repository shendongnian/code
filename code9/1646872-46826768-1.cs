    internal abstract class Token
    {
    }
    internal class OpenNodeToken : Token
    {
        public OpenNodeToken(string name) { Name = name; }
        public string Name { get; }
    }
    internal class CloseNodeToken : Token
    {
    }
    internal class ContentToken : Token
    {
        public ContentToken(string text) { Text = text; }
        public string Text { get; }
    }
