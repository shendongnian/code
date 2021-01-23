      public IQueryable<users> UsersGrid_GetData()
        {
            ModelData db = new ModelData();
            var result = from d in db.users
                     group d by d.Fonction into grouped
                         select new users
                         {
                             Fonction = grouped.Key,
                             Count = grouped.Count()
                         };
            return result;
        }
