        public void MyAddFunction<T>(T newItem, databaseEntities db, 
               Expression<Func<T, bool>> predicate) where T : class
        {
            var table = db.Set<T>();
            int count = table.Count(predicate);
            if(count < 1)
            {
                db.Set<T>().Add(newItem);
            }
            db.SaveChanges();
        }
