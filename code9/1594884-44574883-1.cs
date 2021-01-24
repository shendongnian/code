        public Main()
        {
            InitializeComponent();
            t = new System.Timers.Timer(5000);
            t.Elapsed += T_Elapsed;
        }
        private void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            throw new Exception();
        }
