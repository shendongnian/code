        public event Action<bool> ToggleStateChanged;
        public ButtonLayout()
        {
            InitializeComponent();
            ToggleButton1.Checked += (sender, e) => ToggleStateChanged?.Invoke(true);
            ToggleButton1.UnChecked += (sender, e) => ToggleStateChanged?.Invoke(false);
        }
