    public static readonly DependencyProperty SelectedColorProperty = DependencyProperty.Register("SelectedColor", typeof(Brush), typeof(Colorpicker), new PropertyMetadata(default(Brush), OnSelectedColorChanged));
    private static void OnSelectedColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var newBrush = (Brush)e.NewValue;
        var colorPicker = (Colorpicker)d;
        var comboBox = colorPicker.superCombo;
        // Find your index here using the new Brush value.
        // And update the selected index of your ComboBox.
    }
