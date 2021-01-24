        public BindingSource bindingSource { get; set; } = new BindingSource();
        public BindingList<BindingList<double>> bindingList { get; set; } = new BindingList<BindingList<double>>();
        public BindingList<double> values1 { get; set; } = new BindingList<double>();
        public BindingList<double> values2 { get; set; } = new BindingList<double>();
        public Form1()
        {
            InitializeComponent();
            bindingList.Add(values1);
            bindingList.Add(values2);
            bindingSource.DataSource = bindingList;
            chart1.DataSource = bindingSource;
        }
