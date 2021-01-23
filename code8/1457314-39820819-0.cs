    public class Wrapper
    {
        public _CommentAdmindto Result { get; set; }
    }
    public class _CommentAdmindto
    {
        public long dateTime { get; set; }
        public IEnumerable<CommentDtoAdmin> list { get; set; }
    }
