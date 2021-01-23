    public class Operation
    {
        public int ID { get; set; }
        public string CRUD { get; set; }
    }
    
    var result = list.GroupBy(x => x.ID)
                  .ToDictionary(x => x.Key, x => x.Last().CRUD);
    //if you want to have same List<Operation>
    list = list.GroupBy(x => x.ID)
                .Select(x=> new Operation { ID = x.Key, CRUD = x.Last().CRUD }).ToList();
