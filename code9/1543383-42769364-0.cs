    public partial class PopUpButton : UserControl, INotifyPropertyChanged
    {
        public PopUpButton()
        {
            InitializeComponent();
            _checked = false;
            DrawButton();
        }
        private bool _checked;
        private String _text;
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler ButtonClick;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        protected void Button_Click(object sender, EventArgs e)
        {
            _checked = !_checked;
            DrawButton();
            NotifyPropertyChanged("Checked");
            if (this.ButtonClick != null)
                this.ButtonClick(this, e);
        }
        private void UserControl1_Resize(object sender, EventArgs e)
        {
            DrawButton();
        }
        [Bindable(true)]
        public bool Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                _checked = value;
                DrawButton();
                NotifyPropertyChanged("Checked");
            }
        }
        [Bindable(true)]
        public String DisplayText
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                DrawButton();
            }
        }
        private void HandleClick( )
        {
            _checked = !_checked;
            DrawButton();
            NotifyPropertyChanged("Checked");
        }
        private void DrawButton()
        {
			//do some drawing stuff here
        }
        private void PopUpButton_Resize(object sender, EventArgs e)
        {
            DrawButton();
        }
    }
