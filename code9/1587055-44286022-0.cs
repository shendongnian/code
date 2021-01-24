    public abstract class BaseModel
    {
        public abstract string Address { get; set; }
    }
    public class ChildModel : BaseModel
    {
        [Required]
        public override string Address { get; set; }
    }
    public class AnotherChildModel : BaseModel
    {
        //Not[Required]
        public override string Address { get; set; }
    }
