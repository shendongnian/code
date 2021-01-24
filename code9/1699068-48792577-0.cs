    public Search ()
    { 
        InitizializeComponent();
        Vid.Text= "lol";
        RechercheBtn.Command = new Command(() => SearchVideo(Vid.Text));
    }
