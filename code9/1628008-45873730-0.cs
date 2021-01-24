    public static readonly DependencyProperty SelectedTextProperty = DependencyProperty.Register("SelectedText", typeof(string), typeof(YourClassType));
    public string SelectedText
    {
      get { return (string)GetValue(SelectedTextProperty ); }
      set { SetValue(SelectedTextProperty , value); }
    }
