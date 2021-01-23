    public void UpdateSomething(Something obj)
    {
        var attached = DB.Somethings.Single(x => x.ID == obj.ID);
        Merge(something, attached);
        DB.SaveChanges();
    }
