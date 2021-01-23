    button.Clicked += (sender, e) =>
        {
            App.DB.IncrementScore();
            lblStack.Children.Add(new Label {Text = FontAwesome.FACheck, TextColor = Color.Green, FontFamily = "FontAwesome"});
        };
