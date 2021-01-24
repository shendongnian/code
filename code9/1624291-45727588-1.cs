    public SubWindow()
    {
        InitializeComponent();
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        UserComment = userCommentBox.Text;            
        Close();
    }
    public string UserComment { get; set; }
