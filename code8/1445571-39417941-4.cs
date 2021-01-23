    public partial class UserControl1 : UserControl
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public UserControl1()
            {
                InitializeComponent();
            }
    
            private string stringA;
    
            public string a
            {
                get { return stringA; }
                set
                {
                    if (value != stringA)
                    {
                        stringA = value;
                        if (PropertyChanged!= null)
                        {
                           PropertyChanged(this, new PropertyChangedEventArgs(a));
                        }
                    }
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                a = button1.Text;
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                a = button2.Text;
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                a = button3.Text;
            }
    
            private void button4_Click(object sender, EventArgs e)
            {
                a = button4.Text;
            }
        }
