    public partial class Template : UserControl
    {
        private Button _btn ;
        public Template()
        {
            
        }
        public Button MyButton
        {
            get
            {
                return _button;
            }
            set
            {
                _btn = value;
                _button = value;
            }
        }
        protected override void OnInitialized(EventArgs e)
        {
            InitializeComponent();
            base.OnInitialized(e);
            this._button.Content = _btn.Content;
            this._button.Background = _btn.Background;
            this.Width = _btn.Width;
            this.Height = _btn.Height;
        }
    }
