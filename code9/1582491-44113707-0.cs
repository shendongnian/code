    public static readonly DependencyProperty MaxLengthProperty = DependencyProperty.Register(
      "MaxLength",
      typeof(int),
      typeof(HexBox),
      new PropertyMetadata(0, new PropertyChangedCallback(MaxLength_PropertyChanged))
    );
    private static void MaxLength_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        HexBox hexControl = d as HexBox;
        hexControl.txtValue.MaxLength = (int)e.NewValue;
    }
