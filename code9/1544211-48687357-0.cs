    public class UserEntity
    {
    	public string Name { get; set; }
    }
    
    public interface IRepository
    {
    	UserEntity GetUserEntity();
    }
    
    public sealed class Repository : IRepository
    {
    	public UserEntity GetUserEntity()
    	{
    		return new UserEntity
    		{
    			Name = "User's name"
    		};
    	}
    }
    
    public interface IService
    {
    	UserEntity GetUserEntity();
    }
    
    public sealed class Service : IService
    {
    	private readonly Lazy<IRepository> lazyRepository;
    
    	public Service(Lazy<IRepository> lazyRepository)
    	{
    		this.lazyRepository = lazyRepository;
    	}
    
    	public UserEntity GetUserEntity()
    	{
    		var user = this.lazyRepository.Value.GetUserEntity();
    		return user;
    	}
    }
    
    class Program
    	{
    		static void Main(string[] args)
    		{
    			UnityContainer container = new UnityContainer();
    
    			container.RegisterType<IRepository, Repository>();
    			container.RegisterType<IService, Service>();
    
    			IService resolvedService = container.Resolve<IService>();
    
    			Console.WriteLine($"Name: {resolvedService.GetUserEntity().Name}");
    			
    
    			Console.WriteLine("\n\nTap to continue...");
    			Console.ReadLine();
    		}
    	}
