    correctButton.Clicked += (sender, e) =>
    {
        App.DB.IncrementScore();
        Device.BeginInvokeOnMainThread(() => // On MainThread because it's a change in your UI
        {
            Label label = new Label();
            label.Text = "{x:Static local:FontAwesome.FACheck}"; // Not sure if this is right...
            label.FontFamily = "FontAwesome";
            label.TextColor = Color.Green;
            stackPanel.Children.Add(label);
        });
    };
