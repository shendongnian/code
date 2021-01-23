            var localEntity = dbContext.Set<theModel>()
                .Local
                .FirstOrDefault(f => f.Id == theModel.Id);
            if (localEntity != null)
            {
                dbContext.Entry(localEntity).State = EntityState.Detached;
            }
            dbContext.Entry(appModel).State = EntityState.Modified;
