    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.MaxHeight = SystemParameters.WorkArea.Height;
            this.MaxWidth = SystemParameters.WorkArea.Width;
            // Compensate for the extra space WPF adds by increasing the max width and height here
            //this.MaxHeight = SystemParameters.WorkArea.Height + 12;
            //this.MaxWidth = SystemParameters.WorkArea.Width + 12;
            InitializeComponent();
        }
    }
