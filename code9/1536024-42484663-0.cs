    namespace BSE.UI.Xaml.Controls.Extensions
    {
      public static class ContentDialog
      {
        public static readonly DependencyProperty DialogCancelProperty =
                    DependencyProperty.RegisterAttached("DialogCancel",
                        typeof(bool),
                        typeof(ContentDialog), new PropertyMetadata(false));
        
        public static readonly DependencyProperty CancelableCommandParameterProperty =
                    DependencyProperty.Register("CancelableCommandParameter",
                        typeof(object),
                        typeof(ContentDialog), null);
        
        public static readonly DependencyProperty CancelableCommandProperty =
                    DependencyProperty.RegisterAttached("CancelableCommand",
                        typeof(ICommand),
                        typeof(ContentDialog),
                        new PropertyMetadata(null, OnCancelableCommandChanged));
        
        public static void SetDialogCancel(DependencyObject obj, bool value)
        {
          obj.SetValue(DialogCancelProperty, value);
        }
        
        public static bool GetDialogCancel(DependencyObject obj)
        {
          return (bool)obj.GetValue(DialogCancelProperty);
        }
        
        public static ICommand GetCancelableCommand(DependencyObject obj)
        {
          return (ICommand)obj.GetValue(CancelableCommandProperty);
        }
        
        public static void SetCancelableCommand(DependencyObject obj, ICommand value)
        {
          obj.SetValue(CancelableCommandProperty, value);
        }
        
        public static object GetCancelableCommandParameter(DependencyObject obj)
        {
          return obj.GetValue(CancelableCommandParameterProperty);
        }
        
        public static void SetCancelableCommandParameter(DependencyObject obj, object value)
        {
          obj.SetValue(CancelableCommandParameterProperty, value);
        }
        
        private static void OnCancelableCommandChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
          var contentDialog = obj as Windows.UI.Xaml.Controls.ContentDialog;
          if (contentDialog != null)
          {
            contentDialog.Loaded += (sender, routedEventArgs) =>
            {
             ((Windows.UI.Xaml.Controls.ContentDialog)sender).PrimaryButtonClick += OnPrimaryButtonClick;
            };
          }
        }
        
        private static void OnPrimaryButtonClick(Windows.UI.Xaml.Controls.ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
          var contentDialog = sender as Windows.UI.Xaml.Controls.ContentDialog;
          if (contentDialog != null)
          {
            var command = GetCancelableCommand(contentDialog);
            command?.Execute(GetCancelableCommandParameter(contentDialog));
            args.Cancel = GetDialogCancel(contentDialog);
          }
        }
      }
    }
