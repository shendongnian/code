    public Bracket()
    {
        Content = new ObservableCollection<BaseControl>();
    }
    public static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register(nameof(Content), typeof(ObservableCollection<BaseControl>), 
            typeof(Bracket), new PropertyMetadata(null));
