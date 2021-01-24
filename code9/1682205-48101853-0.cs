    public void SaveProviders(Provider _providers)
    {
      try
        {
                using (var ctx = new SMBASchedulerEntities(this.Connectionstring))
                {
                    ctx.Providers.Add(_providers);
                    ctx.Entry(_providers).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
