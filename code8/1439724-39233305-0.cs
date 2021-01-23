    public class MyControl
    {
        public MyControl()
        {
            InitializeComponent();
    
            int myArgs = 123;
            MyButton.Click += (sender, e) => MyCustomMethod(sender, e, myArgs);
    
        }
        public void MyCustomMethod(object sender, EventArgs e, int myArgs)
        {
    
            // this prints "123" when the button is pressed
            MessageBox.Show(myArgs.ToString());
        }
    }
