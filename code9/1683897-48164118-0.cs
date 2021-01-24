    public class Master {
        public string Id { get; set;}
        public string Name { get; set;}
    }
    var MasterList = _masterListRepo.GetAll().Select(t => new Master {Id = MASTER_ID, Name = t.MASTER_NAME).OrderBy(t=>t.MASTER_NAME).ToList();
