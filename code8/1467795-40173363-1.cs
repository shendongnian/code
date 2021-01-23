    public IQueryable<DTO> UsersGrid_GetData()
    {
        ModelData db = new ModelData();
        var result = from d in db.users
                     group d by d.Fonction into grouped
                     select new DTO
                     {
                         Fonction = grouped.Key,
                         Count = grouped.Count()
                     };
        return result.AsQueryable();
    }
    public class DTO 
    {
        public string Fonction { get; set; }
        public int Count { get; set; }
    }
