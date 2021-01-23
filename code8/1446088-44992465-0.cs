    public static class ButtonExtension
    {
        public static readonly DependencyProperty MenuFlyoutProperty =
            DependencyProperty.Register("MenuFlyout",
                typeof(MenuFlyout), typeof(ButtonExtension),
                new PropertyMetadata(new MenuFlyout(), (sender, e) =>
                {
                    var button = sender as Button;
                    button.Flyout = e.NewValue as MenuFlyout;
                }));
        public static MenuFlyout GetMenuFlyout(DependencyObject obj)
        {
            return (MenuFlyout)obj.GetValue(MenuFlyoutProperty);
        }
        public static void SetMenuFlyout(DependencyObject obj, MenuFlyout value)
        {
            obj.SetValue(MenuFlyoutProperty, value);
        }
    }
