    public partial class Form1 : Form
        {
            public  ArrayList hop = new ArrayList();
    
            public Form1()
            {
                InitializeComponent();
            }      
    
            private void button1_Click(object sender, EventArgs e)
            {
                hop.Add("2016");
                hop.Add("2015");
                Form2 f = new Form2(hop);
                f.checkedListBox2.Text = this.textBox1.Text;
                f.Show();
            }
        }
