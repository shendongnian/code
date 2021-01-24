      public static readonly DependencyProperty NumbersProperty = DependencyProperty.Register(
            "Numbers", typeof(int), typeof(View_Control), new PropertyMetadata(default(int), (s, e) =>
            {
                View_Control view = (View_Control) s;
                int n = (int) e.NewValue;
                ServiceErkaanClient dv = new ServiceErkaanClient();
                view.MyGrid1.ItemsSource = dv.SP_All_SellAsync(n).Result;
            }));
        public int Numbers
        {
            get { return (int) GetValue(NumbersProperty); }
            set { SetValue(NumbersProperty, value); }
        }
        public View_Control()
        {
            ServiceErkaanClient dv = new ServiceErkaanClient();
            this.InitializeComponent();
            MyGrid1.ItemsSource = dv.SP_All_SellAsync(Numbers).Result;
        }
