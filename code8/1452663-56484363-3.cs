    public interface IGenericService<T>
    {
        void Insert(T obj);
    }
    public class GenericService<T> : IGenericService<T> where T : BaseModel
    {
        public void Insert(T obj)
        {
            obj.Id = Guid.NewGuid();
            obj.CreateDate = DateTime.UtcNow;
            this._repository.Insert(obj);           
        } 
    }
