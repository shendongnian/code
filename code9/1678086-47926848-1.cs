        public Form1()
        {
            InitializeComponent();
            customToolstrip1.BtnClickCommand = new RelayCommand<object>(obj => { MessageBox.Show("Button clicked"); });
        }
