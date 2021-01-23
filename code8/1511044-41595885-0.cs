    Public class ClassName
    {
        
        public ClassName(){}
        
        public string Name {get; set;}
        public SomeOtherClass class {get; set;} 
        
        public bool SampleMethod() 
        {
            if (class.StatusId == 1)
                return true;
            else
                return false;
        }
        
    }
        
    public class SomeOtherClass ()
    {
        public int StatusId {get; set;}
        public string StatusDesc { get; set;}
    }
