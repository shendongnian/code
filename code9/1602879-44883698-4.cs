    public static class ToolTipHelper
    {
        public static ToolTip GetToolTip(DependencyObject obj)
        {
            return (ToolTip)obj.GetValue(ToolTipProperty);
        }
        public static void SetToolTip(DependencyObject obj, ToolTip value)
        {
            obj.SetValue(ToolTipProperty, value);
        }
        public static readonly DependencyProperty ToolTipProperty =
            DependencyProperty.RegisterAttached("ToolTip", typeof(ToolTip), typeof(ToolTipHelper), 
            new PropertyMetadata(null, (s, e) =>
            {
                var panel = (Panel)s; // The Grid that contains the ArrowDown control.
                var toolTip = (ToolTip)e.NewValue;
                // We need to monitor SizeChanged instead of Opened 'cause the offsets
                // are yet to be properly set in the latter event.
                toolTip.SizeChanged += (sender, args) =>
                {
                    var popup = (Popup)toolTip.Parent; // The Popup that contains the ToolTip.
                    // Note we have to use the Popup's offset here as the ToolTip's are always 0.
                    var arrowDown = (ArrowDown)panel.FindName("arrowDown");
                    arrowDown.TooltipPlacement = popup.VerticalOffset > 0
                        ? PlacementMode.Bottom
                        : PlacementMode.Top;
                };
            }));
    }
