    var textView = FindViewById<TextView>(Resource.Id.my_label);
    var span = new SpannableString("My Label");
 
    span.SetSpan(new ForegroundColorSpan(Color.Red), 0, 2, 0);  // "My" is red
    span.SetSpan(new ForegroundColorSpan(Color.Blue), 3, 8, 0); // "Label" is blue
    textView.SetText(span, TextView.BufferType.Spannable);
