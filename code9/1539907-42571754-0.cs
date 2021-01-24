    public static class MyServiceExtensions 
    {
         public static IServiceCollection AddMyLibrary(this IServiceCOllection services)
         {
             services.Add<Interface1,Implemenetation1>();
             services.Add<Interface2,Implemenetation2>();
             return services;
         }
    }
