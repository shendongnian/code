    public static class DropDownButtonHelper
    {
        public static readonly DependencyProperty OwnerProperty =
            DependencyProperty.RegisterAttached("Owner", typeof(DropDownButton), typeof(DropDownButtonHelper), new PropertyMetadata(OwnerChanged));
        public static DropDownButton GetOwner(ContextMenu menu)
        {
            return (DropDownButton)menu.GetValue(OwnerProperty);
        }
        public static void SetOwner(ContextMenu menu, DropDownButton value)
        {
            menu.SetValue(OwnerProperty, value);
        }
        private static void OwnerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var menu = (ContextMenu)d;
            if (e.OldValue != null)
                //unsubscribe from the old owner
                ((DropDownButton)e.OldValue).GroupStyle.CollectionChanged -= menu.OwnerGroupStyleChanged;
            if (e.NewValue != null)
            {
                var button = (DropDownButton)e.NewValue;
                //subscribe to new owner
                button.GroupStyle.CollectionChanged += menu.OwnerGroupStyleChanged;
                menu.GroupStyleSelector = button.SelectGroupStyle;
            }
            else
                menu.GroupStyleSelector = null;
        }
        private static void OwnerGroupStyleChanged(this ContextMenu menu, object sender, NotifyCollectionChangedEventArgs e)
        {
            //this method is invoked whenever owners GroupStyle collection is modified,
            //so we need to update the GroupStyleSelector
            menu.GroupStyleSelector = GetOwner(menu).SelectGroupStyle;
        }
        private static GroupStyle SelectGroupStyle(this DropDownButton button, CollectionViewGroup group, int level)
        {
            //we select a proper GroupStyle from the owner's GroupStyle collection
            var index = Math.Min(level, button.GroupStyle.Count - 1);
            return button.GroupStyle.Any() ? button.GroupStyle[index] : null;
        }
    }
