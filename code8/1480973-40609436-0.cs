    public interface IId
    {
        int Id {get;set;}
    }
    
    public static int returnId<T>(T input) where T : IId
    {
        if(input != null && input.Id != null)
        {
            return input.Id;
        }
        return 0;
    }
