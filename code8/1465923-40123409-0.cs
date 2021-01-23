infoPage
     public static InfoPage Current;
     public InfoPage()
     {
         this.InitializeComponent();
         Current = this;      
     }
    public string gettext()
    {
        return txttext.Text;
    }
MainPage
    private void btngetsecondpage_Click(object sender, RoutedEventArgs e)
    {
        InfoPage infopage = InfoPage.Current;
        txtresult.Text = infopage.gettext();  
    }
