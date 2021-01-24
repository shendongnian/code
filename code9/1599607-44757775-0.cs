    (from c in this.dbContext.SomeTable
      where c.Id == someId
      select new SomeModel()
      {
           Id = c.Id,
           Name = c.Name,
           StartDate = c.StartDate!=null ? c.StartDate.DateTime:null // <-- Check null
      }
