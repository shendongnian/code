    public class MyWindow : Window
    {
        // must be a property! This is your instance...
        public YourCollection MyObjects {get; } = new YourCollection();
        public MyWindow()
        {
            // set datacontext to the window's instance.
            this.DataContext = this;
            InitializeComponent();
        }
        public void Button_Click(object sender, EventArgs e)
        {
            // add an object to your collection (instead of directly to the listbox)
            MyObjects.AddTitle("Hi There");
        }
    }
