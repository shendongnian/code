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
            Loaded += ExComboBox_Loaded;
            ClipToBounds = true;
            //assign template selector - just to re-template ContentSite / selection box 
            //uncomment this code - if you want to default-template for popup-items
            //ItemTemplateSelector = new SlidingComboBoxItemTemplateSelector();        
        }
        
        private void ExComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= ExComboBox_Loaded;
            
            //get content-site holder/parent
            _parent = this.GetChildOfType<ContentPresenter>();
            //setup slide animation
            _animation = new DoubleAnimation()
            {
                From = 0,
                RepeatBehavior = SlideForever ? RepeatBehavior.Forever : new RepeatBehavior(1), //repeat only if slide-forever is true
                AutoReverse = SlideForever
            };
            //create storyboard
            _storyBoard = new Storyboard();
            _storyBoard.Children.Add(_animation);
            Storyboard.SetTargetProperty(_animation, new PropertyPath("RenderTransform.(TranslateTransform.X)"));
        }
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            //get actual textblock that renders the selected value
            var textBlock = _parent.GetChildOfType<TextBlock>();
            //and translate-transform for animation
            textBlock.RenderTransform = _translate = new TranslateTransform();
            //start animation only if text-block width is greater than parent
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
            //stop animation once mouse pointer is off the control
            _storyBoard.Stop();
            //reset render state
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
            //create datatemplate with ScrollViewer and TextBlock as child
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
                //send back only if template requested for ContentSite, and not for combo-box item(s)
                return _selectedItemTemplate;
            }
            return null;
        }
    }
    /// <summary>
    /// VisualTree helper
    /// </summary>
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
