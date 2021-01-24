    public interface IContext
    {
        IQueryable<TableName> View { get; set; }
        // put other shared stuff here
    }
