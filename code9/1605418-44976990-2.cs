    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;
    namespace MouseOverPopupButton
    {
        public static class Extensions
        {
            #region Extensions.MouseDownFocusRecipient Attached Property
            //  Attached property. See XAML example below for usage. 
            //  On mouse down, sets focus on bound target control. 
            public static UIElement GetMouseDownFocusRecipient(UIElement obj)
            {
                return (UIElement)obj.GetValue(MouseDownFocusRecipientProperty);
            }
            public static void SetMouseDownFocusRecipient(UIElement obj, UIElement value)
            {
                obj.SetValue(MouseDownFocusRecipientProperty, value);
            }
            public static readonly DependencyProperty MouseDownFocusRecipientProperty =
                DependencyProperty.RegisterAttached("MouseDownFocusRecipient", typeof(UIElement), typeof(Extensions),
                    new PropertyMetadata(null, MouseDownFocusRecipient_PropertyChanged));
            private static void MouseDownFocusRecipient_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var target = d as UIElement;
                //  Target must have some kind of background color or it will ignore mouse events. 
                //  We can't do this object-orientedly because multiple Background dependency 
                //  properties are defined in multiple control classes. 
                var bkgDepProp = DependencyPropertyDescriptor.FromName("Background", target.GetType(), target.GetType(), true);
                if (bkgDepProp != null && bkgDepProp.GetValue(target) == null)
                {
                    bkgDepProp.SetValue(target, System.Windows.Media.Brushes.Transparent);
                }
                //target.IsHitTestVisible = true;
                target.PreviewMouseDown -= Target_PreviewMouseDown;
                target.PreviewMouseDown += Target_PreviewMouseDown;
            }
            private static void Target_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
            {
                var target = (UIElement)sender;
                var otherControl = GetMouseDownFocusRecipient(target);
                if (otherControl != null)
                {
                    Keyboard.Focus(otherControl);
                }
            }
            #endregion Extensions.MouseDownFocusRecipient Attached Property
        }
    }
