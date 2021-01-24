    public static DependencyProperty ForceCloseProperty = DependencyProperty.RegisterAttached (
        "ForceClose", typeof (bool), typeof (...), new UIPropertyMetadata (false, (d, e) =>
        {
            var w  = d as Window ;
            if (w != null && (bool) e.NewValue)
            {
                w.DialogResult = true ;
                w.Close () ;
            }
        })) ;
    <!-- in .xaml -->
    <Window local:ForceClose="{Binding IsButtonLogicComplete}" ...
