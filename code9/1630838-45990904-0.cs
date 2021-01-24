    public SplashWindow()
        : base(Gtk.WindowType.Toplevel)
    {
        this.Build();
        this.SetDefaultSize(250, 250);
        this.SetPosition(WindowPosition.Center);
        ThreadStart tStart = new ThreadStart(this.EndSplash);
        Thread t = new Thread(tStart);
        t.Start();
        Build();
    }
    public void EndSplash()
    {
        Thread.Sleep(1000);
        Gtk.Application.Invoke(
            delegate (object sender, EventArgs args)
            {
                StartApplication();
            }
        );
    }
    private void StartApplication()
    {
        this.Destroy();
        FSD.WelcomeWindow welcome = new FSD.WelcomeWindow();
        welcome.Show();
      
    }
