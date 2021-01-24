    private WelcomePage page = new WelcomePage();
    public void SomeMethod()
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.frame.Content = page;
	    mainWindow.Show();
    }
    private void SomeOtherMethod()
    {
        page.Play();
    }
