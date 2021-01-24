    const string numberRegex = @"^[a-zA-Z]+$";
    private static void OnEntryTextChanged(object sender, TextChangedEventArgs args) 
    {
        if(!string.IsNullOrWhiteSpace(args.NewTextValue)) 
        { 
           IsValid = (Regex.IsMatch(e.NewTextValue, numberRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
           ((Entry)sender).Text = IsValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length -1);       
        }
    }
