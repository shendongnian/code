    public DataRepository()
    {
        this.Data = new DataContext();
    }
    public DataRepository(DataContext data)
    {
        this.Data = data;
    }
