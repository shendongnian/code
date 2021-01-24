    public class GenerateKeyContext : BaseContext
    {
        public GenerateKeyContext(string conString)
            : base(conString, DatabaseGeneratedOption.Identity)
        { }
    }
    
    public class InsertKeyContext : BaseContext
    {
        public InsertKeyContext(string conString)
            : base(conString, DatabaseGeneratedOption.None)
        { }
    }
