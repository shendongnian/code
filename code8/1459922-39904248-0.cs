    async void Name_TextChanged(object sender, TextChangedEventArgs e)
    {
      NameText.Animate("nameAnimation", new Animation(v => NameText.Scale = v, 1, 2, Easing.SpringIn));
      NameText.Text = "MyLabel";
      Name.TextChanged -= Name_TextChanged;
    }
