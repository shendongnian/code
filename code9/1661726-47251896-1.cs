    public void RemoveHardware(T item)
    {
        var dbItem = MDM.Set<T>().FirstOrDefault(x=>x.Id == item.Id);
        if(dbItem!=null)
        {
            MDM.Set<T>().Remove(dbItem);
            MDM.SaveChanges();
        }
    }
