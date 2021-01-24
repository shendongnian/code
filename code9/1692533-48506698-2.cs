    public class AttachCommandBindingsBehavior : Behavior<FrameworkElement>
    {
        public ObservableCollection<CommandBinding> CommandBindings
        {
            get => (ObservableCollection<CommandBinding>)GetValue(CommandBindingsProperty);
            set => SetValue(CommandBindingsProperty, value);
        }
        public static readonly DependencyProperty CommandBindingsProperty =
            DependencyProperty.Register(
                "CommandBindings",
                typeof(ObservableCollection<CommandBinding>),
                typeof(AttachCommandBindingsBehavior),
                new PropertyMetadata(null, OnCommandBindingsChanged));
        private static void OnCommandBindingsChanged(
            DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            var b = sender as AttachCommandBindingsBehavior;
            if (b == null)
                return;
            var oldBindings = e.OldValue as ObservableCollection<CommandBinding>;
            if (oldBindings != null)
                oldBindings.CollectionChanged -= b.OnCommandBindingsCollectionChanged;
            var newBindings = e.OldValue as ObservableCollection<CommandBinding>;
            if (newBindings != null)
                newBindings.CollectionChanged += b.OnCommandBindingsCollectionChanged;
            b.UpdateCommandBindings();
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            UpdateCommandBindings();
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.CommandBindings.Clear();
        }
        private void UpdateCommandBindings()
        {
            if (AssociatedObject == null)
                return;
            AssociatedObject.CommandBindings.Clear();
            if (CommandBindings != null)
                AssociatedObject.CommandBindings.AddRange(CommandBindings);
            CommandManager.InvalidateRequerySuggested();
        }
        private void OnCommandBindingsCollectionChanged(
            object sender,
            NotifyCollectionChangedEventArgs e)
        {
            UpdateCommandBindings();
        }
    }
