    public partial class WaitWindow : Form
    {
        public WaitWindow()
        {
            InitializeComponent();
        }
    
        internal void UpdateMessage(string Message)
        {
            lblMessage.Text = Message;
        }
    
    }
