    public static  ObservableCollection<Evento> StaticEvento;
    public  ObservableCollection<Evento> Eventos { get; set; }
    public MainPage()
    {
        this.InitializeComponent();
        if (StaticEvento == null)
        {
            StaticEvento = new ObservableCollection<Evento>();
            StaticEvento.Add(new Evento { Minuto = "20", Segundo = "00", Icono = "", Accion = "Triple de", Equipo = " Visitante" });
            Eventos = StaticEvento;
        }
    }
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        Eventos = StaticEvento;
    }
