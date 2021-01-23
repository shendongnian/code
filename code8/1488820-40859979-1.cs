    public partial class Form2 : Form
        {
            private Button _button1;
    
            public Button Button1
            {
                get { return _button1; }
                set { _button1 = value; }
            }
    
            public Form2()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                _button1.Visible = false;
            }
        }
