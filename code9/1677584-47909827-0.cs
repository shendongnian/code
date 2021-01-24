    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        public bool HasSize { get; set; } = true;
        public Size Size { get; set; } = new Size(800, 800);
    }
