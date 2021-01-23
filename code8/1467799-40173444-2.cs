      public IQueryable<p> UsersGrid_GetData()
        {
            ModelData db = new ModelData();
            var result = from d in db.users
                     group d by d.Fonction into grouped
                         select new p
                         {
                             Fonction = grouped.Key,
                             Count = grouped.Count()
                         };
            return result;
        }
        public class p
        {
            public int? Fonction { get; set; }
            public int Count { get; set; }
        }
 
