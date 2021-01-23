    public NotifyTask<InitData> Data { get; }
    public MainPage()
    {
      InitializeComponent();
      Data = NotifyTask.Create(InitAsync());
    }
    private async Task<InitData> InitAsync() { ... }
