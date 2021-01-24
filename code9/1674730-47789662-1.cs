        private static readonly DependencyProperty FlowDocumentProperty =
            DependencyProperty.Register("FlowDocument", typeof(FlowDocument), typeof(MenuView),
                new FrameworkPropertyMetadata());
        public FlowDocument FlowDocument
        {
            get { return (FlowDocument)GetValue(FlowDocumentProperty); }
            set { SetValue(FlowDocumentProperty, value); }
        }
