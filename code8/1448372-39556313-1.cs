    public Popup ParentPopup { get; set; }
    public UserControl1()
    {
        InitializeComponent();
    }
    //Opens the child2 UserControl from child1 UserControl
    private void button_Click(object sender, RoutedEventArgs e)
    {
        UserControl2 child2 = new UserControl2();
        Popup p = new Popup();
        child2.Unloaded += Child2_Unloaded;
        child2.ParentPopup = p;
        p.Child = child2;
        p.IsOpen = true;
    }
    //Closes the child1 UserControl when child2 is closed
    private void Child2_Unloaded(object sender, RoutedEventArgs e)
    {
       ParentPopup.IsOpen = false;
    }
