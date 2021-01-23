    public Color Color {
        get { return (Color)this.GetValue(ColorProperty); }
        set { SetValue(ColorProperty, value); }
    }
    public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(HoverButton), new PropertyMetadata(Colors.Black, PropertyChanged);
    public static void PropertyChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs e)
	{
		//some code
	}
