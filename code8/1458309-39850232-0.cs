     public void MarkForDeleteItems<T>(ICollection<T> collection) where T : class
     {
         foreach (var collectionItem in collection.ToList())
         {
             ctx.Entry(collectionItem).State = EntityState.Deleted;
         }
     }
