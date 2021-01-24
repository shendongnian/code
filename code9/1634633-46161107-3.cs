    const string numberRegex = @"^[a-zA-Z]+$";
    private static void OnEntryTextChanged(object sender, TextChangedEventArgs args) 
    {
        if(!string.IsNullOrWhiteSpace(args.NewTextValue)) 
        { 
           IsValid = (Regex.IsMatch(args.NewTextValue, numberRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
           ((Entry)sender).Text = IsValid ? args.NewTextValue : args.NewTextValue.Remove(args.NewTextValue.Length -1);       
        }
    }
