    public abstract class LoadTypeBase
    {
        public int LoadId { get; set; }
        ...
    }
 
    [Table("LoadTableA")]
    public class LoadTypeA : LoadTypeBase
    {
        ...
    }
 
    [Table("LoadTableB")]
    public class LoadTypeA : LoadTypeBase
    {
        ...
    }
