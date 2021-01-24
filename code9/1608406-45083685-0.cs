    using System.Data.Entities;
    using (var context = new MusicStoreDBEntities())
    {
        var bay = context.stringInstrumentItems.Include(i => i.brand)
            .FirstOrDefault(x => x.brand.name == name.Text);
        if (bay != null)
        {
            context.stringInstrumentItems.Remove(bay);
            context.SaveChanges();
        }
    }
