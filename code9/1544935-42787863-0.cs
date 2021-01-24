    private void HornMorphoWindow_Load(object sender, EventArgs e)
    {
        var splashScreen = new Splash();  // This is Splash Form
        splashScreen.Show();
        Application.DoEvents(); // Force the splash screen to be shown
       
        // The newly added line
        PythonEngine.Initialize();
        PythonEngine.BeginAllowThreads();
        //********************************
    
        Task.Factory.StartNew(LoadLibrary).Wait(); // Wait for the library to load
        splashScreen.Close();
    }
