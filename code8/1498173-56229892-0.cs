     public void Remove(int[] ids)
            {
                var entities = EntitySet.Where(x => x.IsActive && ids.Contains(x.Id));
                var task = entities.ForEachAsync(x =>
                {
                    x.IsActive = false;
                    Context.Entry(x).State = EntityState.Modified;
                });
                task.Wait();
                Context.SaveChanges();
            }
