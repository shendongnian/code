    public static class ExpanderEx
    {
        public static readonly DependencyProperty BringIntoViewOnExpandProperty =
                               DependencyProperty.RegisterAttached("BringIntoViewOnExpand", 
                                    typeof(bool), typeof(ExpanderEx), 
                                    new PropertyMetadata(false, OnBringIntoViewOnExpandChanged));
        public static bool GetBringIntoViewOnExpand(DependencyObject obj)
        {
            return (bool)obj.GetValue(BringIntoViewOnExpandProperty);
        }
        public static void SetBringIntoViewOnExpand(DependencyObject obj, bool value)
        {
            obj.SetValue(BringIntoViewOnExpandProperty, value);
        }  
        private static void OnBringIntoViewOnExpandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Expander)
            {
                Expander obj = (Expander)d;
                if (e.NewValue.Equals(true)) 
                    obj.Expanded += Obj_Expanded; 
                else
                    obj.Expanded -= Obj_Expanded;
            }
        }
        private static void Obj_Expanded(object sender, RoutedEventArgs e)
        {
            ((Expander)sender).BringIntoView();
        }
    }
