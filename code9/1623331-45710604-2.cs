    [TemplatePart(Name = PART_Root, Type = typeof(Border))]
    [TemplatePart(Name = PART_ContentHost, Type = typeof(Border))]
    public sealed class SquareButton : Button
    {
        private const string PART_Root = "Root";
        private const string PART_ContentHost = "ContentHost";
        public SquareButton()
        {
            DefaultStyleKey = typeof(SquareButton);
        }
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var root = (Border)GetTemplateChild(PART_Root);
            var contentHost = (Border)GetTemplateChild(PART_ContentHost);
            root.SizeChanged += (s, e) =>
            {
                if (root.ActualWidth > root.ActualHeight)
                {
                    contentHost.Width = contentHost.Height = root.ActualHeight;
                }
                else if (root.ActualWidth < root.ActualHeight)
                {
                    contentHost.Height = contentHost.Height = root.ActualWidth;
                }
            };
        }
    }
