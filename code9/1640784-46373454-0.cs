    public partial class Form1 : Form
    {
        public List<string> stringName = new List<string>();
        public int stringCount = 0;
        public Form1()
        {
            InitializeComponent();
        }
        protected override OnLoad(EventArgs e)
        {
            base.OnLoad(e); //You must remember to call base.OnLoad(e) when you override
            if (!Directory.Exists(@"C:\Example"))
            {
                Directory.CreateDirectory(@"C:\Example");
                StreamWriter exampleText = new StreamWriter(@"C:\Example\Example.txt");
            }
            else
                ReadFromFile();
        }
    }
