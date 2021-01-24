    public MainWindow()
    {
        InitializeComponent();
        br.NavigateToString(@"<a href=""http://messages?id=12948""><img src=""F:\Temp\file12948.jpg"" id=""12948"" width=""180px"" ></a>");
        br.Navigating += this.Br_Navigating;
    }
    
    private void Br_Navigating(object sender, NavigatingCancelEventArgs e)
    {
        if(e.Uri.Host == "messages")
        {
            MessageBox.Show(e.Uri.Query);
            e.Cancel = true;
        }
    }
