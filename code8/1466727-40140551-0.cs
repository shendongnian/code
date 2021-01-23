	var formattedString = new FormattedString ();
	formattedString.Spans.Add (new Span { BackgroundColor = Color.Red, ForegroundColor = Color.Olive, Text = "I got it. Take me to the " });
	formattedString.Spans.Add (new Span { BackgroundColor = Color.Black, ForegroundColor = Color.White, Text = "Home Screen.", FontAttributes=FontAttributes.Bold });
    var label = new Label {
        FormattedText = formattedString
    };
