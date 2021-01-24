    public sealed class MyClass   
    {      
        public int count { get; set; }      
        public bool flag { get; set; }      
        public override string ToString() 
        {
            return string.Format("{0},{1}", count, flag);
        }
    }
