    public class DisabledMouseUpAdorner : Adorner
    {
        private Border _Child;
        private Action _OnDisabledMouseUp;
        public DisabledMouseUpAdorner(FrameworkElement element, Action onDisabledMouseUp)
            : base(element)
        {
            _OnDisabledMouseUp = onDisabledMouseUp;
            _Child = new Border();
            _Child.MouseLeftButtonUp += Adorner_Click;
            // actually you probably want an invisible adorner, but for demonstration lets add some color
            //_Child.Background = new SolidColorBrush(Colors.Transparent);
            _Child.Background = new SolidColorBrush(new Color() { A = 20, R = 255, G = 0, B = 0 });
            _Child.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            _Child.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            _Child.IsHitTestVisible = !element.IsEnabled;
            element.IsEnabledChanged += Adorned_IsEnabledChanged;
            AddVisualChild(_Child);
        }
        void Adorned_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            _Child.IsHitTestVisible = !AdornedElement.IsEnabled;
        }
        void Adorner_Click(object sender, RoutedEventArgs e)
        {
            if (_OnDisabledMouseUp != null)
            {
                _OnDisabledMouseUp();
            }
        }
        protected override int VisualChildrenCount
        { get { return 1; } }
        protected override Visual GetVisualChild(int index)
        {
            if (index != 0) throw new ArgumentOutOfRangeException();
            return _Child;
        }
        protected override Size MeasureOverride(Size constraint)
        {
            _Child.Measure(constraint);
            return base.MeasureOverride(constraint);
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            _Child.Arrange(new Rect(new Point(0, 0), finalSize));
            return finalSize;
        }
    }
    public static class Attached
    {
        public static bool GetToolTipOnClickEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(ToolTipOnClickEnabledProperty);
        }
        public static void SetToolTipOnClickEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(ToolTipOnClickEnabledProperty, value);
        }
        // Using a DependencyProperty as the backing store for ToolTipOnClickEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToolTipOnClickEnabledProperty =
            DependencyProperty.RegisterAttached("ToolTipOnClickEnabled", typeof(bool), typeof(Attached), new PropertyMetadata(false, new PropertyChangedCallback(OnToolTipOnClickChanged)));
        private static void OnToolTipOnClickChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as FrameworkElement;
            if (element != null)
            {
                if (element.IsLoaded)
                {
                    if ((bool)e.NewValue == true)
                    {
                        AddOverlay(element);
                    }
                    else
                    {
                        RemoveOverlay(element);
                    }
                }
                else
                {
                    element.Loaded -= Element_Loaded;
                    element.Loaded += Element_Loaded;
                }
            }
        }
        private static void Element_Loaded(object sender, RoutedEventArgs e)
        {
            var elem = sender as FrameworkElement;
            elem.Loaded -= Element_Loaded;
            if (GetToolTipOnClickEnabled(elem))
            {
                AddOverlay(elem);
            }
            else
            {
                RemoveOverlay(elem);
            }
        }
        private static void RemoveOverlay(FrameworkElement element)
        {
            var adl = AdornerLayer.GetAdornerLayer(element);
            var ad = adl.GetAdorners(element);
            foreach (var item in ad)
            {
                if (item is DisabledMouseUpAdorner) adl.Remove(item);
            }
        }
        private static void AddOverlay(FrameworkElement element)
        {
            var a = AdornerLayer.GetAdornerLayer(element);
            if (a != null)
            {
                a.Add(new DisabledMouseUpAdorner(element, () => ClickHandler(element)));
            }
            else
            {
            }
        }
        // whatever you actually want to do when the adorner triggers
        private static void ClickHandler(FrameworkElement element)
        {
            if (element.ToolTip == null)
            {
                return;
            }
            var tt = element.ToolTip as ToolTip ?? new ToolTip() { Content = element.ToolTip, StaysOpen = false };
            tt.IsOpen = true;
        }
    }
