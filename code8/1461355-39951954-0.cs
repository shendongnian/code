    public class Form1 : Form
    {
        Variables _myVariables;
        public Form1()
        {
            InitializeComponent();
            _myValue = new Variables() { Node = 10 }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("The current value of _myVariables.Node is: " + _myVariables.Node);
        }
    }
