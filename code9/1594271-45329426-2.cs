    public MainWindowViewModel()
    {
      using (var context = new GestDbContext())
      {
        var entity = context.Gestures.Any();
        context.Init();
      }
    }
