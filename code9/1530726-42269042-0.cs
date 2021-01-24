    public static class ChildFillEx
    {
        public static readonly DependencyProperty ChildFillProperty =
            DependencyProperty.RegisterAttached(
                "ChildFill", typeof(Brush), typeof(ChildFillEx),
                new FrameworkPropertyMetadata(
                    null,
                    FrameworkPropertyMetadataOptions.Inherits,
                    ChildFillPropertyChanged));
        public static Brush GetChildFill(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ChildFillProperty);
        }
        public static void SetChildFill(DependencyObject obj, Brush value)
        {
            obj.SetValue(ChildFillProperty, value);
        }
        private static void ChildFillPropertyChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var shape = obj as Shape;
            if (shape != null)
            {
                shape.Fill = (Brush)e.NewValue;
            }
        }
    }
