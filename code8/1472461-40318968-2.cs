    public interface IId
    {
         int Id {get;set;}
    }
    
    public class Person : IId
    {
         public int Id {get; set;}
    }
    public static int getNextId(List<IId>param)
    {
        int lastId = param.Last().Id;
        if (lastId!=0)
        {
            return lastId++;
        }
        return 0;
    }
