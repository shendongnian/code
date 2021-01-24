    public class ApiResourceRepository : ApiResourceRepository {
                private readonly IServiceProvider _serviceProvider;
    
                public ApiResourceRepository(IServiceProvider serviceProvider) {
                    _serviceProvider = serviceProvider;
                }
    
                public object Get(int id) {
                    using (var serviceScope = _serviceProvider.CreateScope()) {
                        var repo = serviceScope.ServiceProvider.GetService<IPersonRepository>();
                        return repo.GetById(id);
                    }
                }
            }
