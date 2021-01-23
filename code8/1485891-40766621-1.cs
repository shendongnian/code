     class Behaviour
    {
     
        public static bool GetForceFoucusBoolean(DependencyObject obj)
        {
            return (bool)obj.GetValue(ForceFoucusBooleanProperty);
        }
        public static void SetForceFoucusBoolean(DependencyObject obj, bool value)
        {
            obj.SetValue(ForceFoucusBooleanProperty, value);
        }
        // Using a DependencyProperty as the backing store for ForceFoucusBoolean.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForceFoucusBooleanProperty =
            DependencyProperty.RegisterAttached("ForceFoucusBoolean", typeof(bool), typeof(Behaviour), new PropertyMetadata(null,
                (o, e) =>
                {
                    TextBox  tb = o as TextBox;
                    if (tb != null)
                    {
                        bool foucs = Convert.ToBoolean(e.NewValue);
                        if (selctAll)
                        {
                            tb.Foucs();
                        }
                        else
                        {
                            tb.Unfocus();
                        }
                    }
                }));
    }
