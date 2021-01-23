     public override int SaveChanges()
        {
            var selectedEntityList = ChangeTracker.Entries();
            foreach (var entity in selectedEntityList)
            {
                var type = entity.GetType();
                var properites = entity.Entity.GetType().GetProperties();
                var pr = properites.SingleOrDefault(p => p.Name == "Position");
                pr.SetValue(entity.Entity, 150, null);
         }
            return base.SaveChanges();
             }
