    public class DocumentViewerBehavior : Behavior<DocumentViewer>
    {
        public static readonly DependencyProperty PageViewChangedCommandProperty = DependencyProperty.Register(nameof(PageViewChangedCommand), typeof(ICommand), typeof(DocumentViewerBehavior));
        public ICommand PageViewChangedCommand
        {
            get => (ICommand)GetValue(PageViewChangedCommandProperty);
            set => SetValue(PageViewChangedCommandProperty, value);
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PageViewsChanged += OnPageViewsChanged;
        }
        private void OnPageViewsChanged(object sender, EventArgs e) => PageViewChangedCommand?.Execute(AssociatedObject.MasterPageNumber);
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PageViewsChanged -= OnPageViewsChanged;
        }
    }
