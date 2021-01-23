    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
            button2.BackColor = Control.DefaultBackColor;
            button3.BackColor = Control.DefaultBackColor;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
            button1.BackColor = Control.DefaultBackColor;
            button3.BackColor = Control.DefaultBackColor;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.Red;
            button2.BackColor = Control.DefaultBackColor;
            button1.BackColor = Control.DefaultBackColor;
            
        }
    }
