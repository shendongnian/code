    TextView textview = FindViewById<TextView>(Resource.Id.Terms);
    //You need add this line
    textview.MovementMethod = LinkMovementMethod.Instance;
    //This is the Text of TextView
    SpannableString ss1 = new SpannableString("You must agree to our terms and conditions");
    
    //22 means start position, ss1.Length() means end position
    ss1.SetSpan(new MyClickableSpan(this), 22, ss1.Length(), SpanTypes.ExclusiveExclusive);
    //set text for your TextView
    textview.TextFormatted = ss1;
 
