    public class TopLevel
    {
        public int Id { get; set; }
        public List<ChildLevel> ChildLevelList { get; set; }
    }
    public class ChildLevel // was ChildLevelList
    {
        public int Id { get; set; }
        public List<ChildLevel1> ChildLevelList1 { get; set; }
    }
    public class ChildLevel1 // was ChildLevel1List
    {
        public int Id { get; set; }
    }
