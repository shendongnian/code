    MyDbContext db = new MyDbContext();
    public List<Menus> GetChildren(int id)
    {
        return db.Menus.Where(i => i.Parent == id || i.Id == id).ToList().Union(db.Menus.Where(i => i.Parent == id).ToList().SelectMany(i => GetChildren(i.Id)).ToList()).ToList();            
    }
    public void DeleteMenus(int id)
    {
        GetChildren(id).ForEach(i => db.Entry(i).State = System.Data.Entity.EntityState.Deleted);
        db.SaveChanges();
    }
