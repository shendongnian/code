    public partial class HeaderFooterWrapPanel : UserControl
    {
        private const int _kheaderIndex = 0;
        private const int _kfooterIndex = 2;
        private readonly CompositeCollection _composedCollection = new CompositeCollection();
        private readonly CollectionContainer _container = new CollectionContainer();
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header", typeof(string), typeof(HeaderFooterWrapPanel),
            new PropertyMetadata((o, e) => _OnHeaderFooterPropertyChanged(o, e, _kheaderIndex)));
        public static readonly DependencyProperty FooterProperty = DependencyProperty.Register(
            "Footer", typeof(string), typeof(HeaderFooterWrapPanel),
             new PropertyMetadata((o, e) => _OnHeaderFooterPropertyChanged(o, e, _kfooterIndex)));
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            "ItemsSource", typeof(IEnumerable), typeof(HeaderFooterWrapPanel),
            new PropertyMetadata(_OnItemsSourceChanged));
        private static void _OnHeaderFooterPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e, int index)
        {
            HeaderFooterWrapPanel panel = (HeaderFooterWrapPanel)d;
            panel._composedCollection[index] = e.NewValue;
        }
        private static void _OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HeaderFooterWrapPanel panel = (HeaderFooterWrapPanel)d;
            panel._container.Collection = panel.ItemsSource;
        }
        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
        public string Footer
        {
            get { return (string)GetValue(FooterProperty); }
            set { SetValue(FooterProperty, value); }
        }
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public HeaderFooterWrapPanel()
        {
            InitializeComponent();
            _container.Collection = ItemsSource;
            _composedCollection.Add(Header);
            _composedCollection.Add(_container);
            _composedCollection.Add(Footer);
            wrapPanel1.ItemsSource = _composedCollection;
        }
    }
