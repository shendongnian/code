    public static string UserName { get; set; }
    public void test_TextChanged(object sender, TextChangedEventArgs e)
    {
        string user = MainPage.textbox1.Text;
        welcomePage.UserName = test.Text;
        box.Text = "User: " + welcomePage.UserName;
     }
