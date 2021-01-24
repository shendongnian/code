    public static void StripUnderlinesFromLinks (this TextView textView) {
                var spannable = new SpannableStringBuilder (textView.TextFormatted);
                var spans = spannable.GetSpans (0, spannable.Length (), Java.Lang.Class.FromType (typeof (URLSpan)));
                foreach (URLSpan span in spans) {
                    var start = spannable.GetSpanStart (span);
                    var end = spannable.GetSpanEnd (span);
                    spannable.RemoveSpan(span);
                    var newSpan = new URLSpanNoUnderline (span.URL);
                    spannable.SetSpan(newSpan, start, end, 0);
                }
                textView.TextFormatted = spannable;
            }
    class URLSpanNoUnderline : URLSpan {
            public URLSpanNoUnderline (string url) : base (url) {
            }
    
            public override void UpdateDrawState (TextPaint ds) {
                base.UpdateDrawState (ds);
                ds.UnderlineText = false;
            }
        }
