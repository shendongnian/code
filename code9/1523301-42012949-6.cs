    public abstract class BaseModel
    {
        [Required]
        public abstract string FieldTest {get; set;}
                                ^^^^^^^
    }
    
    public class ChildModel : BaseModel
    {
        [Email]
        public override string FieldTest {get; set;}
                                ^^^^^^^
                              Store email
    }
    
    public class AnotherChildModel : BaseModel
    {
        [Phone]
        public override string FieldTest {get; set;}
                                ^^^^^^^
                            Store phone number
    }
