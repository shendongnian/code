	ISpanned html;
	if (Build.VERSION.SdkInt >= BuildVersionCodes.N)
		html = Html.FromHtml("<font color='red'> StackOverflow </font>", FromHtmlOptions.ModeLegacy);
	else
		// Obsolete in N+
		html = Html.FromHtml("<font color='blue'> StackOverflow </font>");
	textview.SetText(html, TextView.BufferType.Spannable);
