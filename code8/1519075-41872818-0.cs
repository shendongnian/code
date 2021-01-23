    public class CREATE
    {
        public bool isValidMemberPassword { get; set; }
        public int member_eid { get; set; }
    }
    
    public class RootObject
    {
        public List<CREATE> CREATE { get; set; }
        public string DATE { get; set; }
    }
