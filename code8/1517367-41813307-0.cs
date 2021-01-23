    public class String_Example
    {
        public string _str {get;set;}
    
        public String_Example(string Cadena)
        {
            _str = Cadena;
        }
    }
    public partial class Form1 : Form  
    {
        Program _parent;
        public Form1(Program _parent)
        {
            InitializeComponent();
            _parent = parent;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _parent.test = new String_Example(textBox1.Text);
            this.Close();
        }
    }
    public class Program
    {
        public String_Example test;
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
