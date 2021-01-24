    public interface IBaseEntity
    {
        int Id { get; set; }
    }
    
    public class Photo : IBaseEntity
    {
        public int Id { get; set; }
    
        public float FileSize { get; set; }
    
        public string Url { get; set; }
    }
    
    public class ServiceResult<T> where T : class, IBaseEntity, new()
    {
        public bool Succeed { get; set; }
    
        private T data;
    
        public T Data
        {
            get
            {
                if (data == null)
                    data = new T();
    
                return data;
            }
            set
            {
                data = value;
            }
        }
    }
    
    
    public abstract class BaseService<T> where T : class, IBaseEntity, new()
    {
        public abstract List<ServiceResult<T>> GetAll();
    
        public abstract ServiceResult<T> GetById(int Id);
    }
    
    public class PhotoService : BaseService<Photo>
    {
        public override List<ServiceResult<Photo>> GetAll()
        {
            throw new Exception();
        }
    
        public override ServiceResult<Photo> GetById(int Id)
        {
            throw new Exception();
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }
