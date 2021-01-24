    public MainPage mpInstance;
    public welcomePage(MainPage mp)
    {
        this.InitializeComponent();
        //Will put the MainPage that this was called from into a variable
        this.mpInstance = mp;
    }
    public void test_TextChanged(object sender, TextChangedEventArgs e)
    {
        //Get the instance of main page, and get the textbox1 text.
        string user = this.mpInstance.textbox1.Text;
        string username = test.Text;
        box.Text = "User: " + username;
     }
