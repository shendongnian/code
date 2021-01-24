    public string username;
    public welcomePage()
    {
        this.InitializeComponent();
    }
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        this.username = e.Parameter as string;
    }
    public void test_TextChanged(object sender, TextChangedEventArgs e)
    {
        //string username = test.Text;
        box.Text = "User: " + this.username;
     }
