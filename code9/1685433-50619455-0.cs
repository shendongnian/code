    TextView mytextview = ....;
    var spans = Android.Text.SpannableFactory.Instance.NewSpannable(mytextview.TextFormatted);
    foreach (URLSpan span in spans.GetSpans(0, mytextview.Text.Length, Java.Lang.Class.FromType(typeof(URLSpan))))
    {
        //Use an Android.Text.SpannableStringBuilder to build your new spannabletext
        var ssb = new Android.Text.SpannableStringBuilder();
        //Do your business here.
    }
    //Then set your text to your TextView
    mytextview.SetText(ssb, TextView.BufferType.Spannable);
