    public static bool GetCheckboxChecked(DependencyObject obj)
    {
      return (bool)obj.GetValue(CheckboxCheckedProperty);
    }
    
    public static void SetCheckboxChecked(DependencyObject obj, bool value)
    {
      obj.SetValue(CheckboxCheckedProperty, value);
    }
    
    public static readonly DependencyProperty CheckboxCheckedProperty =
        DependencyProperty.RegisterAttached("CheckboxChecked", typeof(bool), typeof(MainWindow), new PropertyMetadata(false, CheckboxChecked_Changed));
    private static void CheckboxChecked_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      CheckBox chk = d as CheckBox;
      if (chk != null && chk.Tag == null)
      {
        bool chkValue = chk.IsChecked.GetValueOrDefault();
        bool oldValue = (bool)e.OldValue;
        bool newValue = (bool)e.NewValue;
        chk.Tag = true; // Just to prevent an infinite loop
        chk.IsChecked = !chkValue && !newValue || chkValue && !oldValue && newValue ? false : true;
        chk.Tag = null;
      }
    }
