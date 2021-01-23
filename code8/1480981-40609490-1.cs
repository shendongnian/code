    public static int returnId(IId input)
    {
        if(input != null && input.Id != null)
        {
            return input.Id;
        }
        return 0;
    }
    
    public interface IId
    {
       int Id {get; set;}
    }
