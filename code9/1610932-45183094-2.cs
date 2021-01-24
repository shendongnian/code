    //You custom event, has to be inside namespace but outside class
    public delegate void MyCustomEvent(int value);
    public partial class aUserControl : UserControl
    {
        //Here you initialize it
        public event MyCustomEvent CustomEvent;
        public aUserControl()
        {
            InitializeComponent();
        }
        private void theButton_Click( object sender, EventArgs e )
        {
            CustomEvent?.Invoke(5);//using magic number for test
            //You can call this anywhere in the user control to fire the event
        }
    }
