    public class Class1
    {
        public void Foo(Form1 form) // Method with your cycle in class1
        {
            for(int i = 0; i < 100; i++)
            {
                var str = i.ToString(); // Write iterator in local inloop variable for correct capture in lambda
                form.add += () => str; // subscribe on form1 event
            }
        }
    }
    public delegate string DelEventHandler(); // change return type to string
    public partial class Form1 : Form
    {
        public event DelEventHandler add;
        public Class1 class1;
        public Form1()
        {
            InitializeComponent();
            class1 = new Class1();
            class1.Foo(this);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var handler in add.GetInvocationList().Cast<DelEventHandler>()) // Get all subscribers for correct invoke
            {
                textBox1.Text += handler(); // invoke all subscribers and write result to textBox1
            }
        }
    }
