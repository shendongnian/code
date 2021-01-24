        public Progressbar()
        {
            InitializeComponent();
            ProgressEvent.GetInstance().AddModule += AddProgress;
        }
