    public class Next
    {
        public string @ref { get; set; }
    }
    
    public class Item
    {
        public int empno { get; set; }
        public string ename { get; set; }
        public string job { get; set; }
        public int mgr { get; set; }
        public int sal { get; set; }
        public int deptno { get; set; }
    }
    public class RootObject
    {
        public Next next { get; set; }
        public List<Item> items { get; set; }
    }
