    (...)
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
            if (Content == null && Template != null)
                Content = (UIElement)Template.LoadContent();
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
            else if (e.Property == TemplateProperty)
            {
                UnloadContent();
                Content = null;
                if (ShowContent)
                    LoadContent();
            }
        }
    (...)
