    public class SortKey
    {
        [Key]
        public int SortKeyId { get; set; }
        public long SearchId { get; set; }
        public int EntityId { get; set; }
        public string SortId { get; set; }
    }
    using (var db = new Db())
    {
        Dictionary<int, string> dict = new Dictionary<int, string>();
        long searchId = DateTime.Now.Ticks; // Simplfied, either use a guid or a FK to another table
        db.Keys.AddRange(dict.Select(kv => new SortKey { SearchId = searchId, EntityId = kv.Key, SortId = kv.Value }));
        db.SaveChanges();
        var query = from e in db.Entity
                    join k in db.Keys.Where(k => k.SearchId == searchId) on e.Id equals k.EntityId
                    orderby k.SortId;
    }
    // Cleanup the sort key table 
