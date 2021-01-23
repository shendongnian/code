    // Form1-----------------------------------------------------
    public partial class Form1 : Form
    {
        public string myName { get; set; }
        public Form1()
        {
            InitializeComponent();
            MyClass myClass = new MyClass() {Name = "John"};
            myName = myClass.Name;
        }
    }
    public class MyClass
    {
        public string Name { get; set; }
    }
    // Form2-----------------------------------------------------
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Form1 form1 = new Form1();
            this.label1.Text = form1.myName;
        }
    }
