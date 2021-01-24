    public SQLiteDb.Attorney attorney
    {
        get { return (SQLiteDb.Attorney)GetValue(attorneyProperty); }
        set { SetValue(attorneyProperty, value); }
    }
    public static readonly DependencyProperty attorneyProperty = DependencyProperty.Register(
        nameof(attorney), typeof(SQLiteDb.Attorney), typeof(AttorneyDetails),
        new PropertyMetadata(new SQLiteDb.Attorney(), attorneyPropertyChanged));
    private static async void attorneyPropertyChanged(
        DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
        await ((AttorneyDetails)o).GetAttorneysIdentitiesAsync();
    }
 
