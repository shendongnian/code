    interface IDataServiceFactory{
         DataService<T> Get<T>();
    }
    class DataServiceFactory : IDataServiceFactory{
         public DataService<T> Get<T>(){
              //.. your own logic of creating DataService
              return service;
         }
    }
