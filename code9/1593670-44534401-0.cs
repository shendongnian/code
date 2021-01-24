    public partial class Form1 : Form
    {
        private string message = string.Empty;
        public static Form1 form;
        public Form1()
        {
            InitializeComponent();
            form = this;
        }
        public void UpdateTextBox(string message)
        {
            textBox1.Text += message + Environment.NewLine;
            this.Update();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var myClass = new MyClass();
            myClass.DoSomething();
        }
    }
    public class MyClass
    {
        public void DoSomething()
        {
            Log("I did something");
        }
        private void Log(string message)
        {
            Console.WriteLine(message);
            Form1.form.UpdateTextBox(message);
        }
    }
