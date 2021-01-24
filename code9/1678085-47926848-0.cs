    [System.Runtime.InteropServices.ClassInterface(System.Runtime.InteropServices.ClassInterfaceType.AutoDispatch)]
    [System.Runtime.InteropServices.ComVisible(true)]
    public class CustomToolstrip : ToolStrip
    {
        public CustomToolstrip() : base()
        {
            InitializeComponent();
        }
        public void InitializeComponent()
        {
            var btn = new ToolStripButton()
            {
                Text = "Test Button"
            };
            btn.Click += BtnOnClick;
            Items.Add(btn);
        }
        private void BtnOnClick(object sender, EventArgs eventArgs)
        {
            if (BtnClickCommand.CanExecute(null))
            BtnClickCommand.Execute(null);
        }
        public ICommand BtnClickCommand { get; set; }
    }
