        public ContentView()
        {
            InitializeComponent();
            this.FlowDocument = this.RealFlowDocument;
        }
        private static readonly DependencyPropertyKey FlowDocumentPropertyKey =
            DependencyProperty.RegisterReadOnly("FlowDocument", typeof(FlowDocument), typeof(ContentView),
                new FrameworkPropertyMetadata());
        public static readonly DependencyProperty FlowDocumentProperty
            = FlowDocumentPropertyKey.DependencyProperty;
        public FlowDocument FlowDocument
        {
            get { return (FlowDocument)GetValue(FlowDocumentProperty); }
            protected set { SetValue(FlowDocumentPropertyKey, value); }
        }
