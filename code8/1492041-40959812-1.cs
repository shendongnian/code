      public static Entity SetCommonValues(this Entity entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            entity.Created = DateTime.Now;
            entity.Modified = DateTime.Now;
            entity.CreatedBy = Constants.UserName;
            entity.ModifiedBy = Constants.UserName;
            return entity;
        }
