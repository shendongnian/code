    using (Entities context = new Entities())
          {
    
              foreach (var d in documents)
                {
                   context.Documents.Add(d);
                   context.SaveChanges();
                }
          }
     
