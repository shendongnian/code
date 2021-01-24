    public ListPicture GetPicture(string Id)
    {
        ListPicture pic = Pictures.AsNoTracking().FirstOrDefault(x => x.pId == Id);
        return pic;
    }
    
    public void DeletePicture(string Id)
    {
        ListPicture pic = Pictures.Find(id);
        if( pic != null)
        {
           Pictures.Remove(pic);
        }
        SaveChanges();
    }
