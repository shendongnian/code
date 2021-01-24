    public static readonly DependencyProperty Value1Property =
        DependencyProperty.Register("Value1", typeof(string),
          typeof(UC_StatusBox_detailed), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender,
              new PropertyChangedCallback(OnValueChanged)));
    private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
    //my code here
    }
