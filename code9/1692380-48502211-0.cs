    [ContentProperty(nameof(Template))]
    public class ConditionalContentControl : FrameworkElement
    {
        protected override int VisualChildrenCount => Content != null ? 1 : 0;
        protected override Size ArrangeOverride(Size finalSize)
        {
            if (Content != null)
            {
                if (ShowContent)
                    Content.Arrange(new Rect(finalSize));
                else
                    Content.Arrange(new Rect());
            }
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
            if (Content == null)
            {
                if (Template != null)
                    Content = (UIElement)Template.LoadContent();
                if (Content != null)
                {
                    AddLogicalChild(Content);
                    AddVisualChild(Content);
                }
            }
        }
        protected override Size MeasureOverride(Size constraint)
        {
            var desiredSize = new Size();
            if (Content != null)
            {
                if (ShowContent)
                {
                    Content.Measure(constraint);
                    desiredSize = Content.DesiredSize;
                }
                else
                    Content.Measure(new Size());
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
            }
            else if (e.Property == TemplateProperty)
            {
                UnloadContent();
                Content = null;
                if (ShowContent)
                    LoadContent();
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
        private static readonly DependencyPropertyKey ContentPropertyKey = DependencyProperty.RegisterReadOnly(
            nameof(Content),
            typeof(UIElement),
            typeof(ConditionalContentControl),
            new FrameworkPropertyMetadata
            {
                AffectsArrange = true,
                AffectsMeasure = true,
            });
        public static readonly DependencyProperty ContentProperty = ContentPropertyKey.DependencyProperty;
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
        public static readonly DependencyProperty TemplateProperty = DependencyProperty.Register(
            nameof(Template),
            typeof(ControlTemplate),
            typeof(ConditionalContentControl),
            new PropertyMetadata(null));
        public UIElement Content
        {
            get => (UIElement)GetValue(ContentProperty);
            private set => SetValue(ContentPropertyKey, value);
        }
        public ControlTemplate Template
        {
            get => (ControlTemplate)GetValue(TemplateProperty);
            set => SetValue(TemplateProperty, value);
        }
        public bool ShowContent
        {
            get => (bool)GetValue(ShowContentProperty);
            set => SetValue(ShowContentProperty, value);
        }
        #endregion
    }
