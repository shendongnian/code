    public App()
    {
        InitializeComponent();
        Current.MainPage = new LoadingPage();
    }
    
    protected override void OnStart()
    {
        MagicInit();
        base.OnStart();
    }
    
    public static async void MagicInit()
    {
        var f = await FileSystem.Current.LocalStorage.CreateFileAsync("db.sqlite", CreationCollisionOption.OpenIfExists);
        DbConnection = f.Path;
        await DataService.DbFill();
        User = await DataService.Instance.Table<SpUser>().FirstOrDefaultAsync();
        Current.MainPage = User != null ? (Page)new MainPage() : new LoginPage();
    }
