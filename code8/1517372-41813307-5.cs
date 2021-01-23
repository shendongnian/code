    public partial class Form1 : Form  
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Program.test = new String_Example(textBox1.Text);
            this.Close();
        }
    }
    public class Program
    {
        static public String_Example test;  //Notice this is now a static variable, so it can be accessed without a reference to an instance of Program
        static public void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
    
            test = null;
    
            Form1 frm = new Form1(this);
            Application.Run(frm);
    
            MessageBox.Show(test._str);
        }
    }
