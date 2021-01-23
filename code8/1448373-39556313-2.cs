    public Popup ParentPopup { get; set; }
    public UserControl2()
    {
        InitializeComponent();
    }
 
    //Closes the child2 UserControl
    private void button_Click(object sender, RoutedEventArgs e)
    {
        ParentPopup.IsOpen = false;
    }
