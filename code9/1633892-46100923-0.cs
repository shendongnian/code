    async void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            await App.Current.MainPage.DisplayAlert("Test Title", "Test", "OK");
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }
