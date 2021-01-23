    public class User 
    {
        public string Name {get;set;}
        public WorkPlace Place get{ return this.WorkPlace.Where(x => x.IsActive).FirstOrDefault();}
        public bool IsAlive{get;set;}
    }
