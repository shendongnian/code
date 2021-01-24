    public partial class Form1 : Form
    {
        public List<Character> charList = new List<Character>();
        public UserInputForm Child { get; set; }
        public void SetData(string name)
        {
            Character c = new Character();
            c.Name = name;
            charList.Add(c);
        }
        public Form1()
        {
            InitializeComponent();
        } 
        private void button1_Click_1(object sender, EventArgs e)
        {
            UserInputForm uif = new UserInputForm(this);
            uif.Show();
        }  
    }
