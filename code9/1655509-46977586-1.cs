    public static partial class Behaviors
    {
        public static string GetDrag(DependencyObject obj) => (string)obj.GetValue(DragProperty);
        public static void SetDrag(DependencyObject obj, string value) => obj.SetValue(DragProperty, value);
        public static readonly DependencyProperty DragProperty =
            DependencyProperty.RegisterAttached("Drag", typeof(string), typeof(Behaviors), new PropertyMetadata(null, (d, e) =>
            {
                var element = d as UIElement;
                element.MouseMove += (s, a) =>
                {
                    if (a.LeftButton == MouseButtonState.Pressed)
                        DragDrop.DoDragDrop(element, e.NewValue, DragDropEffects.Copy);
                };
            }));
    }
