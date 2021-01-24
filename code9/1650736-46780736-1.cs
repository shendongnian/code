    public abstract class RoutedEventExtension
    {
        public static readonly DependencyProperty EventProperty = DependencyProperty.RegisterAttached(
            "Event", typeof(RoutedEventExtension), typeof(RoutedEventExtension),
            new PropertyMetadata(null, OnEventChanged));
        public static void SetEvent(DependencyObject element, RoutedEventExtension value)
        {
            element.SetValue(EventProperty, value);
        }
        public static RoutedEventExtension GetEvent(DependencyObject element)
        {
            return (RoutedEventExtension) element.GetValue(EventProperty);
        }
        private static void OnEventChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is IInputElement element))
            {
                throw new InvalidOperationException("RoutedEventExtension can only be attached on an IInputElement.");
            }
            var oldValue = (RoutedEventExtension) e.OldValue;
            var newValue = (RoutedEventExtension) e.NewValue;
            oldValue?.Detach();
            newValue.Attach(element);
        }
        protected IInputElement Target { get; private set; }
        private void Attach(IInputElement target)
        {
            Target = target;
            OnAttached();
        }
        private void Detach()
        {
            try
            {
                OnDetaching();
            }
            finally
            {
                Target = null;
            }
        }
        protected abstract void OnAttached();
        protected abstract void OnDetaching();
    }
    public sealed class ClickEvent : RoutedEventExtension
    {
        public event EventHandler Click;
        protected override void OnAttached()
        {
            Target.MouseLeftButtonDown += OnMouseLeftButtonDown;
            Target.MouseLeftButtonUp += OnMouseLeftButtonUp;
            Target.LostMouseCapture += OnLostMouseCapture;
        }
        protected override void OnDetaching()
        {
            Target.MouseLeftButtonDown -= OnMouseLeftButtonDown;
            Target.MouseLeftButtonUp -= OnMouseLeftButtonUp;
            Target.LostMouseCapture -= OnLostMouseCapture;
        }
        private bool _isMouseDown;
        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isMouseDown = true;
            Mouse.Capture(Target);
        }
        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!_isMouseDown)
            {
                return;
            }
            
            Mouse.Capture(null);
            OnClick();
        }
        private void OnLostMouseCapture(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
        }
        private void OnClick()
        {
            Click?.Invoke(this, EventArgs.Empty);
        }
    }
