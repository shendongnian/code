    public sealed class MyDummyControl : Control
    {
        #region fields
        private const string primaryIconName = "PrimaryIcon";
        #endregion fields
        #region UIElements
        private AppBarButton PrimaryIcon;
        #endregion UIElements
        #region Events
        public event Action PrimaryButtonClicked;
        #endregion Events
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            PrimaryIcon = this.GetTemplateChild(primaryIconName) as AppBarButton;
            //in cases with c# versions lower than 6.0
            //consider replacing the null conditional check(?) with the tradional
            //if(BackRequested!=null) and 
            //the lambda's and annonymous methods with { } and methodName()
            if (PrimaryIcon != null)
                PrimaryIcon.Click += (s, args) =>
                {
                    PrimaryButtonClicked?.Invoke();
                };
        }
        public MyDummyControl()
        {
            this.DefaultStyleKey = typeof(MyDummyControl);
        }
        #region Dependancy Properties
        public UIElement HeaderContent
        {
            get { return (UIElement)GetValue(HeaderContentProperty); }
            set { SetValue(HeaderContentProperty, value); }
        }
        // Using a DependencyProperty as the backing store for HeaderContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderContentProperty =
            DependencyProperty.Register("HeaderContent", typeof(UIElement), typeof(MyDummyControl), new PropertyMetadata(null));
        public bool IsPrimaryIconCompact
        {
            get { return (bool)GetValue(IsPrimaryIconCompactProperty); }
            set { SetValue(IsPrimaryIconCompactProperty, value); }
        }
        // Using a DependencyProperty as the backing store for IsPrimaryIconCompact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPrimaryIconCompactProperty =
            DependencyProperty.Register("IsPrimaryIconCompact", typeof(bool), typeof(MyDummyControl), new PropertyMetadata(false));
        public UIElement Content
        {
            get { return (UIElement)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(UIElement), typeof(MyDummyControl), new PropertyMetadata(null));
        public SolidColorBrush HeaderBackground
        {
            get { return (SolidColorBrush)GetValue(HeaderBackgroundProperty); }
            set { SetValue(HeaderBackgroundProperty, value); }
        }
        // Using a DependencyProperty as the backing store for HeaderBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.Register("HeaderBackground", typeof(SolidColorBrush), typeof(MyDummyControl), new PropertyMetadata(new SolidColorBrush(Windows.UI.Colors.Gray)));
        public SymbolIcon Icon
        {
            get { return (SymbolIcon)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(SymbolIcon), typeof(MyDummyControl), new PropertyMetadata(new SymbolIcon(Symbol.Cancel)));
        public string IconLabel
        {
            get { return (string)GetValue(IconLabelProperty); }
            set { SetValue(IconLabelProperty, value); }
        }
        // Using a DependencyProperty as the backing store for IconLabel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconLabelProperty =
            DependencyProperty.Register("IconLabel", typeof(string), typeof(MyDummyControl), new PropertyMetadata(string.Empty));
        #endregion Dependancy Properties
    }
