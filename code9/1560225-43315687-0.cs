    public class DropCommand : Behavior<FrameworkElement>
    {
        public ReactiveCommand<DragEventArgs,Unit> Command
        {
            get => (ReactiveCommand<DragEventArgs,Unit>)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }
        // Using a DependencyProperty as the backing store for ReactiveCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ReactiveCommand<DragEventArgs,Unit>), typeof(DropCommand), new PropertyMetadata(null));
        // Using a DependencyProperty as the backing store for ReactiveCommand.  This enables animation, styling, binding, etc...
        private IDisposable _Disposable;
        protected override void OnAttached()
        {
            base.OnAttached();
            _Disposable = AssociatedObject.Events().Drop.Subscribe( e=> Command?.Execute(e));
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            _Disposable.Dispose();
        }
    }
