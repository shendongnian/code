    public interface IPrimaryKey
    {
         GUID Id {get; set;}
    }
    class Tool : IPrimaryKey {...}
    class Project : IPrimaryKey {...}
