    public string CustomText
      {
          get { return (string)GetValue(CustomTextProperty); }
          set
          {
              SetValue(CustomTextProperty, value);
          }
      }
    
      public static readonly DependencyProperty CustomTextProperty =
          DependencyProperty.Register("CustomText", typeof(string), typeof(CustomRichEditBox), new PropertyMetadata(null, new PropertyChangedCallback(OnCustomTextChanged)));
    
      private static void OnCustomTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
          CustomRichEditBox rich = d as CustomRichEditBox;
          if (e.NewValue != e.OldValue)
            {
                rich.Document.SetText(Windows.UI.Text.TextSetOptions.None, e.NewValue.ToString());
            }
      }
