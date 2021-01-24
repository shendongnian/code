    textview.MovementMethod = LinkMovementMethod.Instance;
    textview.Text = GetString(Resource.String.Home);
    SpannableString ss = new SpannableString(textview.Text);
    ss.SetSpan(new MyClickableSpan(this), 0, ss.Length(), SpanTypes.ExclusiveExclusive);
    textview.SetText(ss, TextView.BufferType.Spannable);
