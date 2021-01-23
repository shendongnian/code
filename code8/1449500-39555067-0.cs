    public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
    
            public string yourName { get; set; }
            public int Age { get; set; }
    
            public Form2(string name, int age)
            {
                InitializeComponent();
    
                yourName = name;
                Age = age;
            }
    
            private void Form2_Load(object sender, EventArgs e)
            {
                label1.Text = yourName;
                label2.Text = Age.ToString();
            }
        }
