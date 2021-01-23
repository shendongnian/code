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
        readonly Program _parent;  //Reference to class which contains global state.  readonly = can only be set in constructor and can never change.
        public Form1(Program parent)
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
        public String_Example test;  //Notice this is now a member variable
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
