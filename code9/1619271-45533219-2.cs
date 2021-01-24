    public static class MenuItemHelper
    {
        /**** Here are the important parts: ****/
        //When IsEnabled changes we need to either hook things up or do the cleanup
        private static void HandleIsEnabledChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var item = (MenuItem)d;
            if ((bool)e.NewValue)
                //We set MenuItem attached property for current Icon
                HandleIconChanged(null, item, EventArgs.Empty);
            else
                //We clear the value of MenuItem attached property
                HandleIconChanged(item.Icon, item, EventArgs.Empty);
        }
        //By using an extension method we get hold of the old value without the need
        //to maintain any kind of dictionary, so we don't need to worry about memory leaks
        private static void HandleIconChanged(
            this object oldValue,
            object sender,
            EventArgs e)
        {
            var item = (MenuItem)sender;
            if (oldValue is DependencyObject oldIcon)
                SetMenuItem(oldIcon, null);
            if (item.Icon is DependencyObject newIcon)
                SetMenuItem(newIcon, item);
            //We need to remove the old handler, because it relates to the old icon
            DependencyPropertyDescriptor
                .FromProperty(MenuItem.IconProperty, item.GetType())
                .RemoveValueChanged(item, item.Icon.HandleIconChanged);
            //We add new handler, so that when the icon changes we get correct old icon
            DependencyPropertyDescriptor
                .FromProperty(MenuItem.IconProperty, item.GetType())
                .AddValueChanged(item, item.Icon.HandleIconChanged);
        }
        /**** The rest is just DP boilerplate code ****/
        private static readonly DependencyPropertyKey MenuItemPropertyKey =
            DependencyProperty.RegisterAttachedReadOnly(
                name: "MenuItem",
                propertyType: typeof(MenuItem),
                ownerType: typeof(MenuItemHelper),
                defaultMetadata: new PropertyMetadata(null));
        public static readonly DependencyProperty MenuItemProperty =
            MenuItemPropertyKey.DependencyProperty;
        public static MenuItem GetMenuItem(DependencyObject d)
            => (MenuItem)d.GetValue(MenuItemProperty);
        private static void SetMenuItem(DependencyObject d, MenuItem value)
            => d.SetValue(MenuItemPropertyKey, value);
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached(
                name: "IsEnabled",
                propertyType: typeof(bool),
                ownerType: typeof(MenuItemHelper),
                defaultMetadata: new PropertyMetadata(false, HandleIsEnabledChanged));
        public static bool GetIsEnabled(MenuItem item)
            => (bool)item.GetValue(IsEnabledProperty);
        public static void SetIsEnabled(MenuItem item, bool value)
            => item.SetValue(IsEnabledProperty, value);
    }
