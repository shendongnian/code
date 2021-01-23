    var firstEntity=this.context.FirstEntities
                           .Where(x=>x.Id==someId)
                           .Include(s => s.SecondEntityCollection);
    this.context.FirstEntities.Remove(firstEntity);
    
    foreach (var s in firstEntity.SecondEntityCollection.ToList())
      {
         this.context.SecondEntityCollection.Remove(s);
      }
       
    this.context.SaveChanges();
