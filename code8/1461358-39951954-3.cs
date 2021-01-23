    public class Form1 : Form
    {
        Variables _myVariables;
        public Form1(Variables variables)
        {
            InitializeComponent();
            _myVariables = variables;
        }
        // ...
    }
    // Then, somewhere else:
    var variables = new Variables() { Node = 10 };
    var myForm = new Form1(variables);
    myForm.Show();
    // or: Application.Run(myForm);
