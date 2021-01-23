        private readonly Dictionary<Keys, Action> _operationsMap = new Dictionary<Keys, Action>(); 
        public Form1()
        {
            InitializeComponent();
            RegisterKeyShortcuts();
        }
        private void RegisterKeyShortcuts()
        {
            _operationsMap.Add(Keys.Control | Keys.F, WhenPressingF);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_operationsMap.ContainsKey(keyData))
            {
                _operationsMap[keyData].Invoke();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        protected void WhenPressingF()
        {
            MessageBox.Show("What the Ctrl+F?");
        }
    }
