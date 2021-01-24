    private void stripUnderlines(TextView textView)
    {
        SpannableString s = new SpannableString(textView.Text);
        s.SetSpan(new URLSpanNoUnderline(textView.Text), 0, s.Length(), SpanTypes.ExclusiveExclusive);
        textView.SetText(s, TextView.BufferType.Spannable);
    }
