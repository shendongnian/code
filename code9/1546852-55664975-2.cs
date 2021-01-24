    public interface IMyEntityRepository : IRepositoryBase<MyEntity>
    {
         //here you can place other implementations your repository doesn't have
    }
    
    public class MyEntityRepository : RepositoryBase<MyEntity>, IMyEntityRepository
    {
    }
