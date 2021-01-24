    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                this.button1.MouseEnter += button1_MouseEnter;
            }
    
            void button1_MouseEnter(object sender, EventArgs e)
            {
                focusedTextBox = null;
    
                if (this.textBox1.Focused)
                {
                    focusedTextBox = this.textBox1;
                }
                
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (focusedTextBox != null)
                {
                    MessageBox.Show(focusedTextBox.Name + " has focuse");
                }
            }
    
            TextBox focusedTextBox;
    
        }
    }
