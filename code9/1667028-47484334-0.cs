    public static class ViewCloser
    {
        public static readonly DependencyProperty DialogResultProperty = DependencyProperty.RegisterAttached(
            "DialogResult",
            typeof(bool?),
            typeof(ViewCloser),
            new PropertyMetadata(DialogResultChanged));
        private static void DialogResultChanged(DependencyObject target, DependencyPropertyChangedEventArgs args)
        {
            var view = target as Window;
            if (view == null)
                return;
            if (view.IsModal())
                view.DialogResult = args.NewValue as bool?;
            else
                view.Close();
        }
        public static void SetDialogResult(Window target, bool? value)
        {
            target.SetValue(DialogResultProperty, value);
        }
    }
    public static class WindowExtender
    {
        public static bool IsModal(this Window window)
        {
            var fieldInfo = typeof(Window).GetField("_showingAsDialog", BindingFlags.Instance | BindingFlags.NonPublic);
            return fieldInfo != null && (bool)fieldInfo.GetValue(window);
        }
    }
