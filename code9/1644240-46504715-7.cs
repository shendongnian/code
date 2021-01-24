    public partial class WindowA : Window, ICommonState
    {
        public WindowA()
        {
            InitializeComponent();
        }
        
        // This property will be injected, do not re-assign
        public CommonState CommonState { get; set; }
    }
