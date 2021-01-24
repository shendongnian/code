    public class SlidingComboBox : ComboBox
    {
        public static readonly DependencyProperty SlideForeverProperty = DependencyProperty.Register("SlideForever", typeof(bool), typeof(SlidingComboBox), new FrameworkPropertyMetadata(false));
        public bool SlideForever
        {
            get { return (bool)GetValue(SlideForeverProperty); }
            set { SetValue(SlideForeverProperty, value); }
        }
        protected ContentPresenter _parent;
        protected DoubleAnimation _animation;
        protected TranslateTransform _translate;
        protected Storyboard _storyBoard;
        public SlidingComboBox()
        {
            Loaded += ExTextBox_Loaded;
            ClipToBounds = true;
            ItemTemplateSelector = new SlidingComboBoxItemTemplateSelector();
        }
        private void ExTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= ExTextBox_Loaded;
            
            _parent = this.GetChildOfType<ContentPresenter>();
            _animation = new DoubleAnimation()
            {
                From = 0,
                RepeatBehavior = SlideForever ? RepeatBehavior.Forever : new RepeatBehavior(1),
                AutoReverse = SlideForever
            };
            _storyBoard = new Storyboard();
            _storyBoard.Children.Add(_animation);
            Storyboard.SetTargetProperty(_animation, new PropertyPath("RenderTransform.(TranslateTransform.X)"));
        }
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            var textBlock = _parent.GetChildOfType<TextBlock>();
            textBlock.RenderTransform = _translate = new TranslateTransform();
            if (_parent.ActualWidth < textBlock.ActualWidth)
            {
                _animation.Duration = TimeSpan.FromMilliseconds(((int)textBlock.Text?.Length * 100));
                _animation.To = _parent.ActualWidth - textBlock.ActualWidth;
                _storyBoard.Begin(textBlock);
            }
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            _storyBoard.Stop();
            var textBlock = _parent.GetChildOfType<TextBlock>();
            textBlock.RenderTransform = _translate = new TranslateTransform();
            base.OnMouseLeave(e);
        }
    }
    public class SlidingComboBoxItemTemplateSelector : DataTemplateSelector
    {
        DataTemplate _selectedItemTemplate;
        public SlidingComboBoxItemTemplateSelector()
        {
            var textBlock = new FrameworkElementFactory(typeof(TextBlock));
            textBlock.SetValue(TextBlock.TextWrappingProperty, TextWrapping.NoWrap);
            textBlock.SetBinding(TextBlock.TextProperty, new Binding("SelectedValue")
            {
                RelativeSource = new RelativeSource { Mode = RelativeSourceMode.FindAncestor, AncestorType = typeof(ComboBox) }
            });
            var scrollViewer = new FrameworkElementFactory(typeof(ScrollViewer));
            scrollViewer.SetValue(ScrollViewer.CanContentScrollProperty, true);
            scrollViewer.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Hidden);
            scrollViewer.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled);
            scrollViewer.AppendChild(textBlock);
            _selectedItemTemplate = new DataTemplate
            {
                VisualTree = scrollViewer
            };
        }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            ComboBoxItem comboBoxItem = container.GetVisualParent<ComboBoxItem>();
            if (comboBoxItem == null)
            {
                return _selectedItemTemplate;
            }
            return null;
        }
    }
    public static class HelperExtensions
    {
        public static T GetChildOfType<T>(this DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) return null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }
        public static T GetVisualParent<T>(this DependencyObject child) where T : Visual
        {
            while ((child != null) && !(child is T))
            {
                child = VisualTreeHelper.GetParent(child);
            }
            return child as T;
        }
    }
