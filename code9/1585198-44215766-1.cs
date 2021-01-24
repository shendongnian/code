    public class MyWindow : Window
    {
        // must be a property!
        public YourCollection MyObjects {get; } = new YourCollection();
        public MyWindow()
        {
            // set datacontext to the window's instance.
            this.DataContext = this;
            InitializeComponent();
        }
        public void Button_Click(object sender, EventArgs e)
        {
            // add an object.
            MyObjects.AddTitle("Hi There");
        }
    }
