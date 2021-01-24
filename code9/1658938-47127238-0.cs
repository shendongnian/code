     {
          public partial class Form1 : Form
          {
            Random rand = new Random();
            public Form1()
        
            {
                InitializeComponent();
            }
        
            private void Form1_Load(object sender, EventArgs e)
            {
        
            }
        
            private void button1_Click(object sender, EventArgs e)
            {
                button1.Location = new Point(rand.Next(0, 750), rand.Next(0, 750));
            }
            int mouseclick = 0;
            private void Form1_MouseClick(object sender, MouseEventArgs e)
            {
           
                if (e.Button != MouseButtons.Right)
                {
                    mouseclick++;
                }
                textBox1.Text = mouseclick.ToString();
        
            }
        
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
        
            }
          }
        }
