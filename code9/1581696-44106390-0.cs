        public MainWindow()
        {
            InitializeComponent();
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.zoom_handler);// Capture Mouse wheel event
            mytrackbar.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.zoom_handler);// Capture Mouse wheel event
            mytrackbar.MouseWheel += (sender, e) => ((HandledMouseEventArgs)e).Handled = true;
        }
