    [ContentProperty("Content")]
    public partial class CustomControl : Thumb
    {
        public CustomControl()
        {
            InitializeComponent();
        }
        public FrameworkElement Content { get; set; }
    }
