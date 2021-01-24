    public ShowListViewModel()
    {         
        using (var db = new MSDBContext())
        {
            var shows = (from s in db.Shows select s).ToList();
            Shows = ToObservableCollection(shows);
        }
    }
