    public interface IId
    {
        int Id {get;}
    }
    
    public static int returnId<T>(T input) where T : IId
    {
        return input != null ? input.Id : 0;
    }
