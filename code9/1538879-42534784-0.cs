    public static class MyBehavior
    {
      public static readonly DependencyProperty AllowOnlyDigitsProperty = DependencyProperty.RegisterAttached(
        "AllowOnlyDigits", typeof(bool), typeof(MyBehavior), new PropertyMetadata(default(bool), OnAllowOnlyDigitsChanged));
      private static void OnAllowOnlyDigitsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
        var textBox = d as TextBox;
        if (textBox == null) return;
        textBox.PreviewTextInput += PreviewTextBoxInput;
      }
      public static void SetAllowOnlyDigits(DependencyObject element, bool value)
      {
        element.SetValue(AllowOnlyDigitsProperty, value);
      }
      private static void PreviewTextBoxInput(object sender, TextCompositionEventArgs e)
      {
        var textbox = sender as TextBox;
        if (!char.IsDigit(e.Text, e.Text.Length - 1))
          e.Handled = true;
      }
      public static bool GetAllowOnlyDigits(DependencyObject element)
      {
        return (bool) element.GetValue(AllowOnlyDigitsProperty);
      }
    }
