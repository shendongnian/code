    public static class Attached
    {
        public static MenuItem GetMirrorSource(DependencyObject obj)
        {
            return (MenuItem)obj.GetValue(MirrorSourceProperty);
        }
        public static void SetMirrorSource(DependencyObject obj, MenuItem value)
        {
            obj.SetValue(MirrorSourceProperty, value);
        }
        // Using a DependencyProperty as the backing store for MirrorSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MirrorSourceProperty =
            DependencyProperty.RegisterAttached("MirrorSource", typeof(MenuItem), typeof(Attached), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnMirrorSourceChanged)));
        private static void OnMirrorSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = d as Button;
            if (button != null)
            {
                // initialize bindings and content image
                button.SetBinding(Button.CommandProperty, new Binding("Command") { Source = e.NewValue });
                button.SetBinding(Button.ToolTipProperty, new Binding("ToolTip") { Source = e.NewValue });
                var content = button.Content as Image;
                if (content == null)
                {
                    content = new Image();
                    content.Stretch = Stretch.None;
                    button.Content = content;
                }
                content.SetBinding(Image.SourceProperty, new Binding("Icon.Source") { Source = e.NewValue });
            }
        }
    }
