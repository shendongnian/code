    public class URLSpanNoUnderline : URLSpan
    {
        public URLSpanNoUnderline(String url) : base(url)
        {
        }
        public override void UpdateDrawState(TextPaint ds)
        {
            base.UpdateDrawState(ds);
            ds.UnderlineText = false;
        }
    }
