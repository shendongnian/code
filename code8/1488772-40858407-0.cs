    public class Operation
    {
        public int ID { get; set; }
        public string CRUD { get; set; }
    }
    
    var result = list.GroupBy(x => x.ID)
                  .ToDictionary(x => x.Key, x => x.Last().CRUD)
                  .Where(x=> x.Value.ToLower() != "remove").ToList();
