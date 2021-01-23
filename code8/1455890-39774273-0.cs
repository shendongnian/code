    public static readonly DependencyProperty SourceProperty =
         DependencyProperty.Register("Source", 
             typeof(IEnumerable), 
             typeof(ComboBoxWithButton), 
             new PropertyMetadata(null));
    public IEnumerable Source
    {
        get { return (IEnumerable)GetValue(SourceProperty); }
        set { SetValue(SourceProperty, value); }
    }
