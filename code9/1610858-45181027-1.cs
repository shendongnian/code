        private int _numbers;
        public int Numbers
        {
            set
            {
                _numbers=value;
                //when the numbers be changed
                ServiceErkaanClient dv = new ServiceErkaanClient();
                MyGrid1.ItemsSource = dv.SP_All_SellAsync(numbers).Result;
            }
            get
            {
                return _numbers;
            }
        }
        public View_Control()
        {
            ServiceErkaanClient dv = new ServiceErkaanClient();
            this.InitializeComponent();
            MyGrid1.ItemsSource = dv.SP_All_SellAsync(numbers).Result;
        }
