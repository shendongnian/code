    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponents();
 
            myButton.Click += myButton_Click;
        }
        public async void myButton_Click(object sender, EventArgs e)
        {
            myButton.Enabled = false;
            await SomeAsyncOrLongRunningOnAnotherThreadTask();
            myButton.Enabled = true;
        }
    }
