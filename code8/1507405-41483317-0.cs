    public class CheckBoxCustomBindingBehavior : Behavior<CheckBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
        }
        public object Source
        {
            get
            {
                return (object)GetValue(SourceProperty);
            }
            set
            {
                SetValue(SourceProperty, value);
            }
        }
        // Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(object), typeof(CheckBoxCustomBindingBehavior), new PropertyMetadata(null, OnSourceChanged));
        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CheckBoxCustomBindingBehavior).ModifyBinding();
        }
        public string Path
        {
            get
            {
                return (string)GetValue(PathProperty);
            }
            set
            {
                SetValue(PathProperty, value);
            }
        }
        // Using a DependencyProperty as the backing store for Path.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PathProperty =
            DependencyProperty.Register("Path", typeof(string), typeof(CheckBoxCustomBindingBehavior), new PropertyMetadata(string.Empty, OnPathChanged));
        private static void OnPathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CheckBoxCustomBindingBehavior).ModifyBinding();
        }
        private void ModifyBinding()
        {
            var source = Source ?? AssociatedObject.DataContext;
            if (source != null && !string.IsNullOrEmpty(Path))
            {
                Binding b = new Binding(Path);
                b.Source = source;
                AssociatedObject.SetBinding(CheckBox.IsCheckedProperty, b);
            }
        }
    }
