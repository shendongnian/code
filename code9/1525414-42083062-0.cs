    private static productForm instance;
    public productForm()
    {
      InitializeComponent();
    }
    public static productForm GetInstance
    {
    get
    {
        if (instance == null || instance.IsDisposed)
        {
            instance = new productForm();
        }
        return instance;
    }
    }
