    public interface IMyInterface
    {
       int Id {get; set;}
    }
    
    public void Test<T>(List<T> rEntity) where T : IMyInterface
    {
        object id = 1;
        var result = rEntity.Where(x => x.id == id);
    }
