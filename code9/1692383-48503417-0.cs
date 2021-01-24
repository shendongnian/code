    [ContentProperty(nameof(Content))]
    public class ConditionalContentControl : FrameworkElement
    {
        private UIElement _Content;
        public UIElement Content
        {
            get => _Content;
            set
            {
                if (ReferenceEquals(value, _Content)) return;
                UnloadContent();
                _Content = value;
                if (ShowContent)
                    LoadContent();
            }
        }
        protected override int VisualChildrenCount => ShowContent && Content != null ? 1 : 0;
        protected override Size ArrangeOverride(Size finalSize)
        {
            if (Content != null && ShowContent)
                Content.Arrange(new Rect(finalSize));
            return finalSize;
        }
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index > VisualChildrenCount - 1)
                throw new ArgumentOutOfRangeException(nameof(index));
            return Content;
        }
        private void LoadContent()
        {
            if (Content != null)
            {
                AddLogicalChild(Content);
                AddVisualChild(Content);
            }
        }
        protected override Size MeasureOverride(Size constraint)
        {
            var desiredSize = new Size();
            if (Content != null && ShowContent)
            {
                Content.Measure(constraint);
                desiredSize = Content.DesiredSize;
            }
            return desiredSize;
        }
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == ShowContentProperty)
            {
                if (ShowContent)
                    LoadContent();
                else
                    UnloadContent();
            }
        }
        private void UnloadContent()
        {
            if (Content != null)
            {
                RemoveVisualChild(Content);
                RemoveLogicalChild(Content);
            }
        }
        #region Dependency properties
        public static readonly DependencyProperty ShowContentProperty = DependencyProperty.Register(
            nameof(ShowContent),
            typeof(bool),
            typeof(ConditionalContentControl),
            new FrameworkPropertyMetadata
            {
                AffectsArrange = true,
                AffectsMeasure = true,
                DefaultValue = false,
            });
        public bool ShowContent
        {
            get => (bool)GetValue(ShowContentProperty);
            set => SetValue(ShowContentProperty, value);
        }
        #endregion
    }
