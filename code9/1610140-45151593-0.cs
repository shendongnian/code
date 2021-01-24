    public NeorisForm()
    {
        InitializeComponent();
        AForgeCamera = new Camera(this);
        AForgeCamera.BuscarDispositivos();
    }
