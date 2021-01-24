    public class Department
    {
        public string Prop1 { get; set; }
        public string Prop2 { set; get; }
    
        public Department(string prop1, string prop2)
        {
            Prop1 = prop1;
            Prop2 = prop2;
        }
    }
    
    public class DeptCode100 : Department
    {
        public string Prop3 { get; set; }
        public string Prop4 { set; get; }
    
        public DeptCode100(string prop1, string prop2, string prop3, string prop4) : base(prop1, prop2)
        {
            Prop3 = prop3;
            Prop4 = prop4;
        }
    }
    
    public class DeptCode200 : Department
    {
        public string Prop5 { get; set; }
        public string Prop6 { set; get; }
    
        public DeptCode200(string prop1, string prop2, string prop5, string prop6) : base(prop1, prop2)
        {
            Prop5 = prop5;
            Prop6 = prop6;
        }
    }
