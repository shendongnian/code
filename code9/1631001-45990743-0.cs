        public event Action<bool> ToggleStateChanged;
        public ButtonLayout()
        {
            InitializeComponent();
            ToggleButton1.Checked += () => ToggleStateChanged?.Invoke(true);
            ToggleButton1.UnChecked += () => ToggleStateChanged?.Invoke(false);
        }
