       public static readonly DependencyProperty RcProperty = DependencyProperty.Register(
            "Rc", typeof(double), typeof(MainPage), new PropertyMetadata(100d));
        public double Rc
        {
            get { return (double) GetValue(RcProperty); }
            set { SetValue(RcProperty, value); }
        }
        public static readonly DependencyProperty LcProperty = DependencyProperty.Register(
            "Lc", typeof(double), typeof(MainPage), new PropertyMetadata(500d));
        public double Lc
        {
            get { return (double) GetValue(LcProperty); }
            set { SetValue(LcProperty, value); }
        }
