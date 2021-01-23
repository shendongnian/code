    namespace Testt
        {
            public partial class Form1 : Form
            {
                public Form1()
                {
                    InitializeComponent();
                }
                public int dimx;
        
                private void button1_Click(object sender, EventArgs e)
                {
                    Form2 f2 = new Form2(this);
                    this.Hide();
                    f2.ShowDialog();
                    this.Show();
        
                    dimx = int.Parse(textBox1.Text);
                    //MessageBox.Show(dimx.ToString());
        
        
                }
            }
        }
