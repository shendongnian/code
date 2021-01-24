    public class Brotherhood
    {
        [ForeignKey(typeof(Child))]
        public int ChildID1 { get; set; }
        [ForeignKey(typeof(Child))]
        public int ChildID2 { get; set; }
    }
