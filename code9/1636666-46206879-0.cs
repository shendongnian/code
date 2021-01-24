    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += (sender, args) => ...; // Occurs after X is pressed. You can cancel closure here.
            this.Closed += (sender, args) => ...; // Occurs when the window is already closed.
        }
    }
