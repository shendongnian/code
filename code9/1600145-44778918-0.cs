    public class Base
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public virtual string Description { get { return "Base"; } }
    }
    
    public class A : Base
    {
        public override string Description { get { return "A"; } }
    }
    
    public class B : Base
    {
        private string extraInfo;
    
        public override string Description { get { return "B"; } }
    
        public string ExtraInfo
        {
            get { return extraInfo; }
            set { extraInfo = value; }
        }
    }
