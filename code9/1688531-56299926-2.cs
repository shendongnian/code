    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    
    namespace AutoMapperProject
    {
        class Program
        {
            private static IServiceProvider _serviceProvider;
            static void Main(string[] args)
            {
                RegisterServices();
                ICustomMapper<UserDTO> service = 
                _serviceProvider.GetService<ICustomMapper<UserDTO>>();
                UserDTO userDTO = service.MapUserToUserDTO();
                DisposeServices();
                Console.WriteLine("Hello AutoMapper!");
            }
            private static void RegisterServices()
            {
                var collection = new ServiceCollection();
                collection.AddAutoMapper(typeof(Program));
                collection.AddScoped<ICustomMapper<UserDTO>, CustomMapper>();
                // ...
                // Add other services
                // ...
                _serviceProvider = collection.BuildServiceProvider();
            }
            private static void DisposeServices()
            {
               if (_serviceProvider == null)
               {
                  return;
               }
               if (_serviceProvider is IDisposable)
               {
                  ((IDisposable)_serviceProvider).Dispose();
               }
            }
        }
    }
