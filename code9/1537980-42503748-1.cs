    public static readonly DependencyProperty ItemWidthProperty = DependencyProperty.Register(
            "ItemWidth", typeof (int), typeof (MainWindow), new PropertyMetadata(170));
        public int ItemWidth
        {
            get { return (int) GetValue(ItemWidthProperty); }
            set { SetValue(ItemWidthProperty, value); }
        }
