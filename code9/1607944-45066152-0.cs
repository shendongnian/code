    this.AsQueryable<Form>().Where(x=>x.Status)
            .GroupBy(item=>new {item.FormId, item.Status})
            .Select(
               new Form {
                 FormId=x.First().FormId,
                 Status=x.First().Status,                            
                 Version=x.OrderByDescending(c=>c.Version).First().Version
              }
           ).ToList();
