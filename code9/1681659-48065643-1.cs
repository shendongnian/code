    public static class AttachedProperties
    {
        // in Visual Studio, the `propa` snippet inserts the boilerplate
        public static DependencyProperty ForceCloseProperty =
            DependencyProperty.RegisterAttached ("ForceClose",
            typeof (bool), typeof (AttachedProperties), new UIPropertyMetadata (false, (d, e) =>
            {
                var w  = d as Window ;
                if (w != null && (bool) e.NewValue)
                {
                    w.DialogResult = true ;
                    w.Close () ;
                }
            })) ;
        public static bool GetForceClose (DependencyObject obj)
        {
            return (bool) obj.GetValue (ForceCloseProperty) ;
        }
        public static void SetForceClose (DependencyObject obj, bool value)
        {
            obj.SetValue (ForceCloseProperty, value) ;
        }
    }
    <!-- in .xaml -->
    <Window
      xmlns:local="clr-namespace:YourNamespace"
      local:AttachedProperties.ForceClose="{Binding IsButtonLogicComplete}" ...
