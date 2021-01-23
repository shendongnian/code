    public Company GetCompany(int id)
    {
        using (var context = new DBData())
        {
            context.Configuration.LazyLoadingEnabled = false;
            return context.Set<Company>()
                .Include(x => x.Customer)//you can add other includes which you want
                .Where(x => x.Id == id).FirstOrDefault();
        }
    }
