    public static readonly DependencyProperty ThisSentenceProperty =
        DependencyProperty.Register(
            "ThisSentence",
            typeof(MainPage),
            typeof(ObservableCollection<Book>),
            new PropertyMetadata(null));
    public ObservableCollection<Book> ThisSentence
    {
        get { return (ObservableCollection<Book>)GetValue(ThisSentenceProperty); }
        set { SetValue(ThisSentenceProperty, value); }
    }
