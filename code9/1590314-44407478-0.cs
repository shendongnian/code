    public partial class MyControl : UserControl
    {
        public event OnButtonClicked ButtonClicked;
        public MyControl()
        {
            InitializeComponent();
        }
        private void MyButton_Click(object sender, EventArgs e)
        {
            if(ButtonClicked != null)
            {
                ButtonClicked((Button)sender);
            }
        }
    }
    public delegate void OnButtonClicked(Button button);
