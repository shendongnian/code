    using Microsoft.Extensions.DependencyInjection; 
    ...
    public IFileInfo GetFileInfo(string subpath)
    {
        IHttpContextAccessor httpContextAccessor = MyServiceLocator.ServiceProvider.GetService<IHttpContextAccessor>();			
    }
