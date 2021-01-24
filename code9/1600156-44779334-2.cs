    public List<Pacient> ListaPacienti { get; set; }
    Pacient p1 = new Pacient(0, "Pacient1", 0, 200);
    Pacient p2 = new Pacient(1, "Pacienct2", 0, 100);
    public Form2()
    {
        InitializeComponent();
        ListaPacienti = new List<Pacient>()
        ListaPacienti.Add(p1);
        ListaPacienti.Add(p2);
    }
