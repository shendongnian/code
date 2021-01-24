    public int B
    {
        get { return (int)GetValue(BProperty); }
        set { SetValue(BProperty, value); }
    }
    public static readonly DependencyProperty BProperty = DependencyProperty.Register
    (
      "B",
      typeof(int),
      typeof(ColourSelection),
      new PropertyMetadata(0, PropertyChangedCallback)
    );
    private static void PropertyChangedCallback(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        if ((int) e.NewValue <= 255 && (int) e.NewValue >= 0)
            ((ColourSelection) obj).UpdateColour();
    }
