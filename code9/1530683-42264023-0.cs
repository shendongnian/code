    public IEnumerable<PostJob> GetAllJobsByUserId(int id)
     {
         using (var context = new CleanerDataContext(@"Data Source=.\sqlexpress;Initial Catalog='Cleaning Lady';Integrated Security=True"))
         {
             var loadOptions = new DataLoadOptions();
             loadOptions.LoadWith<PostJob>(c => c.Cleaner);
             loadOptions.LoadWith<PostJob>(c => c.User);
             context.LoadOptions = loadOptions;
             return context.PostJobs.Include(x=>x.Cleaner).Where(r => r.userId == id).ToList();
         }
     }
