    public class Sample
    {
        public virtual int x { get; set; }
        public virtual string y { get; set; }
    }
    
    public class SampleA : Sample
    {
    }
    
    public class SampleB : Sample
    {    
        [Decorated]
        public override string y { get; set; }
    }
