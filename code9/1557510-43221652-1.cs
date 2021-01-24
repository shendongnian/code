    private string entryText;
    public string EntryText
    {
        get { return entryText; }
        set
        {
            if (value != entryText)
            {
                entryText = value;
                Entry2.Text = entryText;
            }
        }
    }
    private void Entry2_TextChanged(object sender, TextChangedEventArgs e)
    {
        entryText = Entry2.Text;
    }
    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        // initialize controls
        EntryText = "Default";
    }
