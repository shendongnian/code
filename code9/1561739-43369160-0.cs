    //BAD IMPLEMENTATION!
    private ObservableCollection<CProyecto> prope;
    public ObservableCollection<CProyecto> Prope
    {
        get
        {
            if (prope == null)
                LoadData().Wait();
            return proyectos;
        }
        set { prope = value; RaisePropertyChanged(); }
    }
