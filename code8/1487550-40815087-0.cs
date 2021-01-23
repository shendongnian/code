        TestViewModel vm;
        public XMainPage()
        {
            InitializeComponent();
            vm = new TestViewModel();
            BindingContext = vm;
        }
