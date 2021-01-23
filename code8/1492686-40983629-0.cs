    public inteface IMyDataContext<TObject> where TObject is class
    {
        TObject FindById(int id); //call FindId
        void Update(TObject); //call DbEntityEntry SetValues
        void SaveChanges();
    }
