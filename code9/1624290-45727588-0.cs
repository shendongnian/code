    public MainWindow()
    {
        InitializeComponent();
        List<Test> items = new List<Test>();
        lvUsers.Items.Add(new Test() { Name = "User A" });
        lvUsers.Items.Add(new Test() { Name = "User B" });
        lvUsers.Items.Add(new Test() { Name = "User C" });
    }
    private int clickedRowIndex = -1;
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var item = (sender as FrameworkElement).DataContext;
        clickedRowIndex = lvUsers.Items.IndexOf(item);
        SubWindow subWindow = new SubWindow();
        subWindow.Closed += SubWindow_Closed;
        subWindow.Show();
    }
    private void SubWindow_Closed(object sender, EventArgs e)
    {
        SubWindow sw = (SubWindow)sender;
        Test t = (Test)lvUsers.Items[clickedRowIndex];
        t.Comment = sw.UserComment;
        lvUsers.Items.Refresh();
    }
