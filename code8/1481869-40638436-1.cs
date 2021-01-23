    public interface IDatasource
    {
        ListModel Data { get; }
    }
    internal class StephensService : IDatasource
    {
        ListModel Data { get; } = new ListModel(); // or however you plan to procure the data
    }
    // ... bootstrapper / module initialization ...
    Container.RegisterType<IDatasource, StephensService>( new ContainerControllerLifetimeManager() );
    // ...
    internal class ListModuleViewModel
    {
        public ListModuleViewModel( IDatasource datasource )
        {
             var heresMyData = datasource.Data;
        }
    }
