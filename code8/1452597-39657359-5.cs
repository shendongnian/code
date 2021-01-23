    public void UpdateSomething(Something obj)
    {
        var attached = DB.Somethings.Single(x => x.ID == obj.ID);
        Merge(obj, attached);
        DB.SaveChanges();
    }
