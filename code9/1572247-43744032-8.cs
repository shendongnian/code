    public class NoCommentJsonTextWriter : JsonTextWriter
    {
        public NoCommentJsonTextWriter(TextWriter writer)
            : base(writer)
        {
        }
        public override void WriteComment(string text)
        {
        }
	}
