        public pws()
        {
            InitializeComponent();
        }
        public pws(IInterfaceTasks tasks) : this()
        {
            _tasks = tasks;
        }
