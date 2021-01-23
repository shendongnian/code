    public Item DeepClone(Parent item)
    {
        Parent itemClone = db.Parents
            .Include(i => i.Childrens1.Select(c => c.Childrens2 ))
            .Include(i => i.Childrens3.Select(c => c.Childrens4 ))
            .AsNoTracking()
            .FirstOrDefault(i => i.IdParent == item.IdParent);
        db.Items.Add(itemClone);
        db.SaveChanges();
        return itemClone;
    }
